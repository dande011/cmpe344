// read in BoneScript library
var b = require('bonescript');

// define used pins
var LED_RED = 'P9_42';
var LED_GREEN = 'P9_14';
var LED_BLUE = 'P9_16';
var BUTTON = 'P8_19';
var POT = 'P9_36';
var S_DATA  = 'P9_18';
var S_CLOCK = 'P9_22';
var S_LATCH = 'P9_17';
var S_CLEAR = 'P9_15';

// define other global variables
var s = b.LOW;
var digit = 0;
var segments = [ 0xC0, 0xF9, 0xA4, 0xB0, 0x99,
                 0x92, 0x82, 0xF8, 0x80, 0x90 ];
var stopped = 0;
var started = 0;
var platform = {};

// attach jQuery elements
try {
    $('#slider1').slider();
    $('#slider2').slider();
    $('#slider3').slider();
    $('#led1').css('width', '50px');
    $('#led1').css('height', '50px');
    $('#led1').css('background-color', 'rgb(0,0,0)');
    $("#slider3").bind("slidechange", function(event, ui) {
        updateRed({value:(ui.value/100.0)});
    });
    //$('#runbutton').removeAttr('onclick');
    $('#runbutton').click(runClick);
} catch(ex) {}

// configure pins as inputs/outputs
b.pinMode(S_DATA,  b.OUTPUT);
b.pinMode(S_CLOCK, b.OUTPUT);
b.pinMode(S_LATCH, b.OUTPUT);
b.pinMode(S_CLEAR, b.OUTPUT);
b.pinMode('USR0', b.OUTPUT);
b.pinMode('USR1', b.OUTPUT);
b.pinMode('USR2', b.OUTPUT);
b.pinMode('USR3', b.OUTPUT);
//b.pinMode(LED_RED, b.OUTPUT);
//b.pinMode(LED_GREEN, b.OUTPUT);
//b.pinMode(LED_BLUE, b.OUTPUT);
b.pinMode(BUTTON, b.INPUT);

// initial states
b.digitalWrite('USR0', b.LOW);
b.digitalWrite('USR1', b.LOW);
b.digitalWrite('USR2', b.LOW);
b.digitalWrite('USR3', b.LOW);
b.analogWrite(LED_RED, 0);
b.analogWrite(LED_GREEN, 0);
b.analogWrite(LED_BLUE, 0);
b.digitalWrite(S_DATA,  b.LOW);
b.digitalWrite(S_CLOCK, b.LOW);
b.digitalWrite(S_LATCH, b.LOW);
b.digitalWrite(S_CLEAR, b.HIGH);
//b.attachInterrupt(BUTTON, true, b.CHANGE, handleButton);

// call function to read status and perform updates
function start() {
    console.log('Starting Bacon Cape demo');
    b.getPlatform(onGetPlatform);
}

function onGetPlatform(x) {
    platform = x;
    scheduleNextUpdate();
}

function scheduleNextUpdate() {    
    // test for stop and then schedule next update for 50ms
    if(stopped) {
        started = 0;
        console.log('Stopped Bacon Cape demo');
    } else {
        setTimeout(update, 50);
    }
}

function update() {
    // toggle USR0 LED
    s = (s == b.LOW) ? b.HIGH : b.LOW;
    if(platform.bonescript != '0.2.3') {
        b.digitalWrite('USR0', s, doAnalogRead);
    } else {
        b.digitalWrite('USR0', s, do7SegUpdate);
    }
}

function do7SegUpdate(x) {
    // update 7segment LED
    digit = (digit + 1) % 10;
    
    // shift out the character LED pattern
    b.shiftOut(S_DATA, S_CLOCK, b.MSBFIRST, 
        segments[digit], doLatch);
}

function doLatch() {
    // latch in the value
    b.digitalWrite(S_LATCH, b.HIGH, doLatchLow);
}

function doLatchLow() {
    b.digitalWrite(S_LATCH, b.LOW, doAnalogRead);
}

function doAnalogRead() {
    b.digitalRead(BUTTON, updateBlue);
}

function updateBlue(x) {
    if(typeof x.value == 'undefined') return;
    updateLED({blue:1-x.value});
    b.analogRead(POT, updateGreen);
}

function updateGreen(x) {
    if(typeof x.value == 'undefined') return;
    updateLED({green:1-x.value});
    scheduleNextUpdate();
}

function updateRed(x) {
    if(started) {
        if(typeof x.value == 'undefined') return;
        updateLED({red:x.value});
    }
}

function updateLED(led) {
    if(typeof led.red == 'number') {
        b.analogWrite(LED_RED, led.red);
        this.red = led.red;
    }
    if(typeof led.green == 'number') {
        b.analogWrite(LED_GREEN, led.green);
        this.green = led.green;
    }
    if(typeof led.blue == 'number') {
        b.analogWrite(LED_BLUE, led.blue);
        this.blue = led.blue;
    }
    try {
        if(typeof this.red == 'undefined') this.red = 0;
        if(typeof this.green == 'undefined') this.green = 0;
        if(typeof this.blue == 'undefined') this.blue = 0;
        var rgb = 'rgb(' + Math.round(this.red*255) + ',' + 
            Math.round(this.green*255) + ',' +
            Math.round(this.blue*255) + ')';
        $('#led1').css('background-color', rgb);
        $("#slider1").slider("option", "value", this.blue*100);
        $("#slider2").slider("option", "value", this.green*100);
    } catch(ex) {}
}

function runClick() {
    if(!started) {
        started = 1;
        stopped = 0;
        start();
        try {
            $('#runbutton').html('stop');
        } catch(ex) {}
    } else if(!stopped) {
        stopped = 1;
        var p = '/sys/class/leds/beaglebone:green:usr';
        b.digitalWrite('USR0', b.LOW);
        b.digitalWrite('USR1', b.LOW);
        b.digitalWrite('USR2', b.LOW);
        b.digitalWrite('USR3', b.LOW);
        b.writeTextFile(p+'0/trigger', 'heartbeat');
        b.writeTextFile(p+'1/trigger', 'mmc0');
        b.writeTextFile(p+'2/trigger', 'cpu0');
        b.writeTextFile(p+'3/trigger', 'mmc1');
        try {
            $('#runbutton').html('run');
        } catch(ex) {}
    } 
}
