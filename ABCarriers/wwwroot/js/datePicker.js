$(document).ready(function () {
    // Initialize Nepali Date Picker
    $('#miti').nepaliDatePicker({
        dateFormat: "%y-%m-%d",
        closeOnDateSelect: true,
        defaultDate: "",               // Set a default date (optional)
        minDate: "२०००-०१-०१",
        maxDate: "२०८०-१२-३०"
    });
});