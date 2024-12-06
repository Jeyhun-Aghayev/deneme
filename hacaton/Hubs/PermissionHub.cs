namespace hacaton.Hubs
{
	using Microsoft.AspNetCore.SignalR;
	using hacaton.Models;
	using System.Threading.Tasks;

	public class PermissionHub : Hub
	{
		// İcazə tələbinin adminə göndərilməsi
		public async Task SendVacationRequest(VacationRequest request)
		{
			// Adminə tələbi göndərmək
			await Clients.Group("Admin").SendAsync("ReceiveVacationRequest", request);
		}

		// Adminin cavabını işçiyə göndərmək
		public async Task SendApprovalResponse(int requestId, bool isApproved)
		{
			// Cavabın Statusunu yeniləyirik
			var responseStatus = isApproved ? "Approved" : "Rejected";
			var responseMessage = isApproved ? "İcazə təsdiq olundu." : "İcazə rədd olundu.";

			// Burada verilən cavabı işçiyə göndəririk
			await Clients.Client(requestId.ToString()).SendAsync("ReceiveApprovalResponse", responseStatus, responseMessage);
		}

		// Admin qrupa qoşularkən
		public async Task JoinAdminGroup()
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, "Admin");
		}
	}
}