// Write your JavaScript code.

// Selects time which was clicked and put the time to route
function select() {
    if(document.getElementById("selected")) {
        jQuery("#selected").attr("id", "");
    }
    document.getElementById("submit").disabled = false;
    jQuery(this).attr("id", "selected");
    var formaction = jQuery("#submit").attr("formaction").split("=");
    formaction[formaction.length - 1] = $(this).attr("hourStart");
    jQuery("#submit").attr("formaction", formaction.join('='));
}
function deleteHoursChilds() {
    var hours = document.getElementById("hours");
    while (hours.firstChild) {
        hours.removeChild(hours.firstChild);
    }
}
// With ajax get all avilable hour intervals
function onCalendarChange(id) {
    var date = document.getElementById("Date").value.split("-");
    document.getElementById("submit").disabled = true;
    if (date[0] == "") {
        deleteHoursChilds();
        return;
    }
    var y = date[0];
    var m = date[1];
    var d = date[2];
    $.ajax({
        type: "GET",
        data: { roomId: id, year: y, month: m, day: d },
        url: "/Reservations/FreeHours",
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            var hours = document.getElementById("hours");
            deleteHoursChilds();
            $.each(response, function (i, item) {
                var button = document.createElement('button');
                button.innerHTML = item + " - " + (item + 1);
                button.classList.add("time-interval");
                button.setAttribute("hourStart",item)
                hours.appendChild(button);
                hours.append(" ");
                button.addEventListener('click', select, false);
            });
        },
        failure: function (response) {
            alert("Failed to load data!");
        }
    });
}