import Adafruit_BBIO.GPIO as GPIO

#GPIO.setup("PX_XX", GPIO.OUT)
GPIO.setup("P9_42", GPIO.OUT) #LED-RED
GPIO.setup("P9_14", GPIO.OUT) #LED_GREEN
GPIO.setup("P9_16", GPIO.OUT) #LED_BLUE
GPIO.setup("P8_19", GPIO.OUT) #BUTTON
GPIO.setup("P9_36", GPIO.OUT) #POT
GPIO.setup("P9_18", GPIO.OUT) #S_DATA
GPIO.setup("P9_22", GPIO.OUT) #S_CLOCK
GPIO.setup("P9_17", GPIO.OUT) #S_LATCH
GPIO.setup("P9_15", GPIO.OUT) #S_CLEAR

segments = [ 0xC0, 0xF9, 0xA4, 0xB0, 0x99, 0x92, 0x82, 0xF8, 0x80, 0x90, 0x88, 0x83, 0xA7, 0xA1, 0x86, 0x8E ]

GPIO.output("P9_42", GPIO.HIGH)

GPIO.cleanup()