import Adafruit_BBIO.GPIO as GPIO
import Adafruit_BBIO.PWM as PWM
import Adafruit_BBIO.ADC as ADC
from Adafruit_BBIO.SPI import SPI
import time
import math

ADC.setup()
spi = SPI(0,0)
#spi.writebytes([1])

PWM.start("P9_42", 0) #LED-RED
PWM.start("P9_14", 0) #LED-GREEN
PWM.start("P9_16", 0) #LED-BLUE
#PWM.set_duty_cycle("P9_42", 1) #RED
#PWM.set_duty_cycle("P9_42", 0) #RED
#PWM.set_duty_cycle("P9_14", 1) #GREEN
#PWM.set_duty_cycle("P9_14", 0) #GREEN
#PWM.set_duty_cycle("P9_16", 1) #BLUE


GPIO.setup("P8_19", GPIO.IN) #BUTTON

LEDS = [ "P9_42", "P9_14", "P9_16" ]
segments = [ [0xC0], [0xF9], [0xA4], [0xB0], [0x99], [0x92], [0x82], [0xF8], [0x80], [0x90], [0x88], [0x83], [0xA7], [0xA1], [0x86], [0x8E] ]


#7-segment writing
def part01() :
	num = 0
	prevNum = 0
	while 1 :
		time.sleep(0.1)
		if (  not(GPIO.input("P8_19")) and  prevNum==0  ) :
			num = num + 1
			prevNum = 1
		if ( GPIO.input("P8_19") ) :
			prevNum = 0
		spi.writebytes(segments[ num%16 ] )
		num = num % 16

def part02() :
	while 1 : 
		#print int(  ADC.read_raw("P9_36")/115  )
		spi.writebytes(segments[ int(  ADC.read_raw("P9_36")/115  ) ] )
		
def part03() :
	num = 0
	while 1 :
		time.sleep(0.1)
		if (  not(GPIO.input("P8_19")) and  prevNum==0  ) :
			print LEDS[num] + " " + str(ADC.read_raw("P9_36")/180)
			PWM.set_duty_cycle(LEDS[num],ADC.read_raw("P9_36")/180 )
			num = num + 1
			prevNum = 1
		if ( GPIO.input("P8_19") ) :
			prevNum = 0
		num = num % 3
		
##### --- MAIN ---

#part01()
#part02()
part03()

#while i<12 : PWM.set_duty_cycle("P9_42", not GPIO.input("P8_19")) #RED
#while i<12 : print GPIO.input("P8_19")
#while 1 : print ADC.read_raw("P9_36")
#while 1 : print ADC.read("P9_36")


time.sleep(5)

GPIO.cleanup()
PWM.cleanup()
#ADC.cleanup()
spi.close()

exit()