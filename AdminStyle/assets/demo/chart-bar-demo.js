// Set new default font family and font color to mimic Bootstrap's default styling

// Bar Chart Example
var ctx = document.getElementById("myFoo");
var myLineChart = new Chart(ctx, {
  type: 'bar',
  data: {
    labels: [ "February", "March", "April", "May", "June"],
      datasets:
        [{
            label: "Revenue",
            backgroundColor: "rgba(2,117,216,1)",
            borderColor: "rgba(2,117,216,1)",
            borderWidth: 2,
            data: [5000, 5312, 6251, 7841, 9821, 14984],
        }],
  },
  options: {
    scales: {
      xAxes: [{
        time: {
          unit: 'month'
        },
        gridLines: {
          display: false
        },
        ticks: {
          maxTicksLimit: 6
        }
      }],
      yAxes: [{
        ticks: {
          min: 0,
          max: 17000,
          maxTicksLimit: 5
        },
        gridLines: {
          display: true
        }
      }],
    },
    legend: {
      display: true
    }
  }
});
