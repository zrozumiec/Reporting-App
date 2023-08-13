let failureIdDetail = "0";

function showCalendarEvents(events) {
    document.addEventListener('DOMContentLoaded', function () {
        let calendarEl = document.getElementById('calendar');
        let data = events;

        let calendar = new FullCalendar.Calendar(calendarEl, {
            weekNumbers: true,
            navLinks: true,
            headerToolbar: {
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,timeGridWeek,timeGridDay'
            },
            eventClick: function (info) {
                info.jsEvent.preventDefault(); // don't let the browser navigate
                let eventObj = info.event;
                failureIdDetail = eventObj.groupId;
                openModal(eventObj.title, eventObj.url, eventObj.startStr, eventObj.endStr);
            },
            events: data,
        });
        calendar.render();
    });
}

function showCalendar() {
    document.addEventListener('DOMContentLoaded', function () {
        let calendarEl = document.getElementById('calendar');

        let calendar = new FullCalendar.Calendar(calendarEl, {
            weekNumbers: true,
            navLinks: true,
            headerToolbar: {
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,timeGridWeek,timeGridDay'
            },
        });
        calendar.render();
    });
}

function openModal(title, url, start, end) {
    $('#modalData1').text("Failure title: " + title);
    $('#modalData2').text("Solution title: " + url);
    $('#modalData3').text("Start date: " + start);
    $('#modalData4').text("End date: " + end);
    $('#myModal').modal('show');
}
s
function closeModal() {
    $('#myModal').modal('hide');
}

function goToAction() {
    let failureId = Number(failureIdDetail)
    closeModal();
    window.location.href = "/Failure/Details/" + failureId;
}


