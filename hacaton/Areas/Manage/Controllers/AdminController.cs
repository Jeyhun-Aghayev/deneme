using hacaton.DataAccess;
using hacaton.Hubs;
using hacaton.Services; // EmailService'i daxil edirik
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

public class AdminController : Controller
{
	private readonly IHubContext<PermissionHub> _hubContext;
	private readonly EmailService _emailService; // EmailServisi əlavə edirik
	private readonly AppDBContext _context;

	public AdminController(IHubContext<PermissionHub> hubContext, EmailService emailService,AppDBContext context)
	{
		_hubContext = hubContext;
		_emailService = emailService; // Email servisini injekt edirik
		_context = context;
	}

	// Adminin icazə tələbinə cavab verməsi və e-poçt göndərilməsi
	[HttpPost("approve-vacation-request")]
	public async Task<IActionResult> ApproveVacationRequest(int requestId, bool isApproved)
	{
		// Cavab veriləcək statusu təyin et
		var responseStatus = isApproved ? "Approved" : "Rejected";
		var responseMessage = isApproved ? "İcazə təsdiq olundu." : "İcazə rədd olundu.";

		// E-poçt göndərmək üçün istifadəçiyə məlumat göndəririk
		var vacationRequest = _context.vacationRequests.FirstOrDefault(v => v.Id == requestId);

		if (vacationRequest != null)
		{
			// Statusu dəyişdiririk
			vacationRequest.Status = responseStatus;
			await _context.SaveChangesAsync();

			// E-poçt göndəririk
			await _emailService.SendEmailAsync(vacationRequest.Employee.Email,
				"İcazə Tələbiniz Haqqında Məlumat",
				responseMessage);
		}

		// Admin cavabını SignalR ilə işçiyə göndəririk
		await _hubContext.Clients.Client(requestId.ToString()).SendAsync("ReceiveApprovalResponse", responseStatus, responseMessage);

		return Ok(new { Message = "Cavab və e-poçt göndərildi!" });
	}
}
