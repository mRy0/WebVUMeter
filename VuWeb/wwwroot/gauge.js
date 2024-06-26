function CreateGauge(name) {

    var opts = {
        angle: 0, // The span of the gauge arc
        lineWidth: 0.41, // The line thickness
        radiusScale: 1, // Relative radius
        pointer: {
            length: 0.53, // // Relative to gauge radius
            strokeWidth: 0.06, // The thickness
            color: '#000000' // Fill color
        },
        limitMax: true,     // If false, max value increases automatically if value > maxValue
        limitMin: true,     // If true, the min value of the gauge will be fixed
        colorStart: '#6FADCF',   // Colors
        colorStop: '#8FC0DA',    // just experiment with them
        strokeColor: '#E0E0E0',  // to see which ones work best for you
        generateGradient: true,
        highDpiSupport: true,     // High resolution support
        // renderTicks is Optional
        renderTicks: {
            divisions: 10,
            divWidth: 1.6,
            divLength: 0,
            divColor: '#333333',
            subDivisions: 10,
            subLength: 0.44,
            subWidth: 0.1,
            subColor: '#666666'
        }

    };
    var target = document.getElementById(name); // your canvas element
    var gauge = new Gauge(target).setOptions(opts); // create sexy gauge!
    gauge.maxValue = 100; // set max gauge value
    gauge.setMinValue(0);  // Prefer setter over gauge.minValue = 0
    gauge.animationSpeed = 128; // set animation speed (32 is default value)
    gauge.set(0); // set actual value

    return gauge;
}


function UpdateGauge(ele, value) {

    ele.set(value);

}