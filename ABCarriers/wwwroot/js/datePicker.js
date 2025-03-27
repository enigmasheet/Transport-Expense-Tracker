$(document).ready(function () {

    // Initialize Datepicker with options
    $("#miti").nepaliDatePicker({
        ndpYear: true,          // Enable Year selection
        ndpMonth: true,         // Enable Month selection
        ndpYearCount: 10,       // Number of years to display in the dropdown
        language: "english",    // Set the language to English
        dateFormat: "DD/MM/YYYY"
    });
});