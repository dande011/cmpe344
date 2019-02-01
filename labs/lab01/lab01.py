import Adafruit_BBIO.GPIO as GPIO
import Adafruit_BBIO.PWM as PWM

PWM.start("P9_42", 0) #LED-RED
PWM.start("P9_14", 0) #LED-GREEN
PWM.start("P9_16", 0) #LED-BLUE
#PWM.set_duty_cycle("P9_42", 1) #RED
#PWM.set_duty_cycle("P9_14", 1) #GREEN
#PWM.set_duty_cycle("P9_16", 1) #BLUE


GPIO.setup("P8_19", GPIO.IN) #BUTTON
GPIO.setup("P9_36", GPIO.IN) #POT
GPIO.setup("P9_18", GPIO.OUT) #S_DATA
GPIO.setup("P9_22", GPIO.OUT) #S_CLOCK
GPIO.setup("P9_17", GPIO.OUT) #S_LATCH
GPIO.setup("P9_15", GPIO.OUT) #S_CLEAR

segments = [ 0xC0, 0xF9, 0xA4, 0xB0, 0x99, 0x92, 0x82, 0xF8, 0x80, 0x90, 0x88, 0x83, 0xA7, 0xA1, 0x86, 0x8E ]


#7-segment writing

GPIO.output("P9_15", GPIO.HIGH) #S_CLEAR
GPIO.output("P9_15", GPIO.LOW) #S_CLEAR

for i in range(8):
	GPIO.output("P9_18", GPIO.HIGH) #S_DATA
	GPIO.output("P9_22", GPIO.HIGH) #S_CLOCK
	GPIO.output("P9_22", GPIO.LOW) #S_CLOCK
GPIO.output("P9_17", GPIO.HIGH) #S_LATCH
GPIO.output("P9_17", GPIO.LOW) #S_LATCH
	

GPIO.cleanup()

exit()