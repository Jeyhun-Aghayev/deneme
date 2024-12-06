// Initialize the application
document.addEventListener('DOMContentLoaded', () => {
    // Populate the table with data
    populateTable();

    // Add event listeners for apply buttons
    document.querySelectorAll('.apply-btn').forEach(button => {
        button.addEventListener('click', (e) => {
            const card = e.target.closest('.leave-card');
            const leaveType = card.querySelector('.type').textContent;
            alert(`Applying for ${leaveType}`);
        });
    });

    // Add event listener for export button
    document.querySelector('.export-btn').addEventListener('click', () => {
        alert('Exporting data...');
    });

    // Add event listener for filter button
    document.querySelector('.filter-btn').addEventListener('click', () => {
        alert('Opening filters...');
    });
});


function populateTable() {
    const tableBody = document.querySelector('#leaveTable tbody');
    tableBody.innerHTML = '';

    leaveData.forEach(entry => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${entry.name}</td>
            <td>${entry.duration}</td>
            <td>${entry.startDate}</td>
            <td>${entry.endDate}</td>
            <td>${entry.type}</td>
            <td>${entry.reason}</td>
            <td>
                <button class="action-btn">Actions</button>
            </td>
        `;
        tableBody.appendChild(row);
    });
}

const leaveData = [
    {
        id: 1,
        name: "Abenezer kebede",
        duration: 5,
        startDate: "22/04/2022",
        endDate: "28/04/2022",
        type: "Sick",
        reason: "Personal"
    },
    {
        id: 2,
        name: "Abenezer kebede",
        duration: 7,
        startDate: "22/04/2022",
        endDate: "30/04/2022",
        type: "Exam",
        reason: "Examination"
    },
    {
        id: 3,
        name: "Abenezer kebede",
        duration: 120,
        startDate: "22/04/2022",
        endDate: "28/06/2022",
        type: "Maternity",
        reason: "Child Care"
    }
];