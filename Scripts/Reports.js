// Load the Visualization API and the corechart package.
google.charts.load('current', { 'packages': ['corechart'] });

// Set a callback to run when the Google Visualization API is loaded.
//google.charts.setOnLoadCallback(drawChart);

// Callback that creates and populates a data table,
// instantiates the pie chart, passes in the data and
// draws it.
//Create Month Array
var months = ['January', 'Feburary', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

function test() {
    alert("Hello World");
}



function GetFleetViolationsByMonth() {

    //Create DataTable
    var data = new google.visualization.DataTable();

    //Create columns
    data.addColumn('string', 'Month');
    data.addColumn('number', 'JPT');
    data.addColumn('number', 'WLT');
    data.addColumn('number', 'POR');

    //Get Data
    var arr = document.getElementById("ContentPlaceHolder1_ViolationsByMonth").getAttribute("data-test").split(",");

    //Clean up dataset
    arr.pop();

    //Add Rows
    var i = 0;
    var n = 1;
    var k = 2;
    var j = 3;
    while (i <= arr.length - 1 / 4) {
        data.addRows([[months[arr[i]-1], parseInt(arr[n]), parseInt(arr[k]), parseInt(arr[j])]]);
        i += 4;
        n += 4;
        k += 4;
        j += 4;
    }
    
    var options = {
        title: 'Fleet Performance - Last Six Months',
        curveType: 'function',
        legend: { position: 'bottom' }
    };

    var chart = new google.visualization.LineChart(document.getElementById('ChartTopCenter'));

    chart.draw(data, options);
}

function GetViolationsByFleetJPT() {

    //Create DataTable
    var data = new google.visualization.DataTable();

    //Create columns
    data.addColumn('string', 'Month');
    data.addColumn('number', 'HOS Violation');
    data.addColumn('number', 'Failed Inspection');
    data.addColumn('number', 'Citation');

    //Get Data
    var arr = document.getElementById("ContentPlaceHolder1_JPTViolations").getAttribute("data-test").split(",");

    //Clean up dataset
    arr.pop();

    //Add Rows
    var i = 0;
    var n = 1;
    var k = 2;
    var j = 3;
    while (i <= arr.length - 1 / 4) {
        data.addRows([[months[arr[i] - 1], parseInt(arr[n]), parseInt(arr[k]), parseInt(arr[j])]]);
        i += 4;
        n += 4;
        k += 4;
        j += 4;
    }

    var options = {
        title: 'JPT Violations - Last Six Months',
        curveType: 'function',
        legend: { position: 'bottom' }
    };

    var chart = new google.visualization.LineChart(document.getElementById('ChartCenterLeft'));

    chart.draw(data, options);
}

function GetViolationsByFleetWLT() {

    //Create DataTable
    var data = new google.visualization.DataTable();

    //Create columns
    data.addColumn('string', 'Month');
    data.addColumn('number', 'HOS Violation');
    data.addColumn('number', 'Failed Inspection');
    data.addColumn('number', 'Citation');

    //Get Data
    var arr = document.getElementById("ContentPlaceHolder1_WLTViolations").getAttribute("data-test").split(",");

    //Clean up dataset
    arr.pop();

    //Add Rows
    var i = 0;
    var n = 1;
    var k = 2;
    var j = 3;
    while (i <= arr.length - 1 / 4) {
        data.addRows([[months[arr[i] - 1], parseInt(arr[n]), parseInt(arr[k]), parseInt(arr[j])]]);
        i += 4;
        n += 4;
        k += 4;
        j += 4;
    }

    var options = {
        title: 'WLT Violations - Last Six Months',
        curveType: 'function',
        legend: { position: 'bottom' }
    };

    var chart = new google.visualization.LineChart(document.getElementById('ChartCenterCenter'));

    chart.draw(data, options);
}
function GetViolationsByFleetPOR() {

    //Create DataTable
    var data = new google.visualization.DataTable();

    //Create columns
    data.addColumn('string', 'Month');
    data.addColumn('number', 'HOS Violation');
    data.addColumn('number', 'Failed Inspection');
    data.addColumn('number', 'Citation');

    //Get Data
    var arr = document.getElementById("ContentPlaceHolder1_PORViolations").getAttribute("data-test").split(",");

    //Clean up dataset
    arr.pop();

    //Add Rows
    var i = 0;
    var n = 1;
    var k = 2;
    var j = 3;
    while (i <= arr.length - 1 / 4) {
        data.addRows([[months[arr[i] - 1], parseInt(arr[n]), parseInt(arr[k]), parseInt(arr[j])]]);
        i += 4;
        n += 4;
        k += 4;
        j += 4;
    }

    var options = {
        title: 'POR Violations - Last Six Months',
        curveType: 'function',
        legend: { position: 'bottom' }
    };

    var chart = new google.visualization.LineChart(document.getElementById('ChartCenterRight'));

    chart.draw(data, options);
}