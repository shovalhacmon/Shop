var margin = {
        top: 40,
        right: 20,
        bottom: 30,
        left: 40
    },
    width = 960 - margin.left - margin.right,
    height = 500 - margin.top - margin.bottom;

var formatPercent = d3.format(".0%");

var x = d3.scale.ordinal()
    .rangeRoundBands([0, width], .1);

var y = d3.scale.linear()
    .range([height, 0]);

var xAxis = d3.svg.axis()
    .scale(x)
    .orient("bottom");

var yAxis = d3.svg.axis()
    .scale(y)
    .orient("left")

var tip = d3.tip()
    .attr('class', 'd3-tip')
    .offset([-10, 0])
    .html(function (d) {
        return "<strong>Quantity:</strong> <span style='color:red'>" + d.amount + "</span>";
    })

var svg = d3.select("#graph-container").append("svg")
    .attr("width", width + margin.left + margin.right)
    .attr("height", height + margin.top + margin.bottom)
    .append("g")
    .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

svg.call(tip);

let convertData = (data) => {
    let monthNames = ["January", "February", "March", "April", "May", "June",
"July", "August", "September", "October", "November", "December"]
    let arr = [];
    for (month in data)
        arr.push({
            month: monthNames[Number(month) - 1],
            amount: data[month]
        })
    return arr;
}

let displayData = (data) => {
    data = convertData(data);
    x.domain(data.map(d => d.month));
    y.domain([0, d3.max(data, d => d.amount)]);

    svg.append("g")
        .attr("class", "x axis")
        .attr("transform", "translate(0," + height + ")")
        .call(xAxis);

    svg.append("g")
        .attr("class", "y axis")
        .call(yAxis)
        .append("text")
        .attr("transform", "rotate(-90)")
        .attr("y", 6)
        .attr("dy", ".71em")
        .style("text-anchor", "end")
        .text("Quantity");

    svg.selectAll(".bar")
        .data(data)
        .enter().append("rect")
        .attr("class", "bar")
        .attr("x", d => {
            return x(d.month);
        })
        .attr("width", x.rangeBand())
        .attr("y", d => {
            return y(d.amount);
        })
        .attr("height", d => {
            return height - y(d.amount);
        })
        .on('mouseover', tip.show)
        .on('mouseout', tip.hide)
}
