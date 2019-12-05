// Load the Visualization API and the corechart package.
google.charts.load('current', { 'packages': ['corechart'] });
google.charts.load('current', { 'packages': ['table'] });

// Set a callback to run when the Google Visualization API is loaded.
//google.charts.setOnLoadCallback(drawChart);

// Callback that creates and populates a data table,
// instantiates the pie chart, passes in the data and
// draws it.
//Create Month Array
var months = ['January', 'Feburary', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];



//function FleetChecker() {
//    if (document.getElementById("ContentPlaceHolder1_Violations").getAttribute("data-name") == "JPT") {
//        GetViolationsByFleetJPTDetails();
//    }
//    if (document.getElementById("ContentPlaceHolder1_Violations").getAttribute("data-name") == "WLT") {
//        GetViolationsByFleetWLTDetails();
//    }
//    if (document.getElementById("ContentPlaceHolder1_Violations").getAttribute("data-name") == "POR"){
//        GetViolationsByFleetPORDetails();
//    }
    
//}






function GetViolationsByFleetDetails() {

    //Create DataTable
    var data = new google.visualization.DataTable();

    //Create columns
    data.addColumn('string', 'Month');
    data.addColumn('number', 'HOS Violation');
    data.addColumn('number', 'Failed Inspection');
    data.addColumn('number', 'Citation');

    //Get Data
    var arr = document.getElementById("ContentPlaceHolder1_Violations").getAttribute("data-test").split(",");
    var fleet = document.getElementById("ContentPlaceHolder1_Violations").getAttribute("data-name");
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
        title: fleet + ' Violations - Last Six Months',
        curveType: 'function',
        legend: { position: 'bottom'}
    };

    var options2 = {
        title: 'JPT Violations - Last Six Months',
        width: '100%',
        height: '100%'
    };


    var chart = new google.visualization.LineChart(document.getElementById('reportDetailsTopView'));
    var chart2 = new google.visualization.Table(document.getElementById('reportDetailsBottomView'));
    chart.draw(data, options);
    chart2.draw(data, options2);
}

