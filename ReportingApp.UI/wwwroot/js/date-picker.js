flatpickr.l10ns.default.firstDayOfWeek = 1; // Monday default is sunday

document.getElementById("flatpickrcontainerStartDate").flatpickr({
    wrap: true,
    minDate: "today",
    weekNumbers: true,
    enableTime: true, // enables timepicker default is false
    time_24hr: true, // set to false for AM PM default is false
    defaultDate: "today",
});

document.getElementById("flatpickrcontainerEndDate").flatpickr({
    wrap: true,
    minDate: "today",
    weekNumbers: true,
    enableTime: true, // enables timepicker default is false
    time_24hr: true, // set to false for AM PM default is false
    defaultDate: "today",
});