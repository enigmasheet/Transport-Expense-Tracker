$(document).ready(function () {
    try {
        // Check if the #miti element exists before initializing the datepicker
        if ($("#miti").length > 0) {
            // Initialize Datepicker with options
            $("#miti").nepaliDatePicker({
                ndpYear: true,          // Enable Year selection
                ndpMonth: true,         // Enable Month selection
                ndpYearCount: 10,       // Number of years to display in the dropdown
                language: "english",    // Set the language to English
                dateFormat: "DD/MM/YYYY"
            });
        }
    } catch (error) {
        console.error("Error initializing Nepali DatePicker:", error);
        // You can choose to log the error or just suppress it
    }
});