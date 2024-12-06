const connection = new signalR.HubConnectionBuilder()
    .withUrl("/permissionHub")
    .build();

// Bağlantı başladıqdan sonra
connection.start().then(function () {
    console.log("SignalR bağlantısı quruldu!");
}).catch(function (err) {
    return console.error(err.toString());
});

// İcazə tələbi göndərmək
function sendVacationRequest(employeeId, startDate, endDate) {
    const request = {
        EmployeeId: employeeId,
        StartDate: startDate,
        EndDate: endDate,
        Status: "Pending"
    };

    connection.invoke("SendVacationRequest", request)
        .catch(function (err) {
            return console.error(err.toString());
        });
}

// Admin cavabını qəbul etmək

connection.on("ReceiveApprovalResponse", function (status, message) {
    if (status === "Approved") {
        alert(message); // Cavab müsbət (icazə təsdiq olundu)
    } else {
        alert(message); // Cavab mənfi (icazə rədd olundu)
    }
});