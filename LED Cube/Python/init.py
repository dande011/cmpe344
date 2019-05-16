
import utime
from Maix import GPIO

CUBESIZE = 8

print("fm registers:")
fm.register(board_info.LED_R, fm.fpioa.GPIO0)
fm.register(1,fm.fpioa.GPIOHS3)
fm.register(2,fm.fpioa.GPIOHS4)
fm.register(3,fm.fpioa.GPIOHS5)
fm.register(6,fm.fpioa.GPIOHS6)
fm.register(7,fm.fpioa.GPIOHS7)
fm.register(8,fm.fpioa.GPIOHS8)
fm.register(9,fm.fpioa.GPIOHS9)
fm.register(10,fm.fpioa.GPIOHS10)
fm.register(15,fm.fpioa.GPIOHS15)
fm.register(16,fm.fpioa.GPIOHS16)
fm.register(17,fm.fpioa.GPIOHS17)
fm.register(18,fm.fpioa.GPIOHS18)
fm.register(19,fm.fpioa.GPIOHS19)
fm.register(20,fm.fpioa.GPIOHS20)
fm.register(30,fm.fpioa.GPIOHS21)
fm.register(31,fm.fpioa.GPIOHS22)
fm.register(32,fm.fpioa.GPIOHS23)
fm.register(33,fm.fpioa.GPIOHS24)
fm.register(34,fm.fpioa.GPIOHS25)
fm.register(35,fm.fpioa.GPIOHS26)

addr = []
LS = []
data = []

print("GPIO Asignments:")
led_r=GPIO(GPIO.GPIO0,GPIO.OUT)
addr.append(GPIO(GPIO.GPIOHS3,GPIO.OUT))
addr.append(GPIO(GPIO.GPIOHS4,GPIO.OUT))
addr.append(GPIO(GPIO.GPIOHS5,GPIO.OUT))
oe=GPIO(GPIO.GPIOHS6,GPIO.OUT)
LS.append(GPIO(GPIO.GPIOHS7,GPIO.OUT))
LS.append(GPIO(GPIO.GPIOHS8,GPIO.OUT))
LS.append(GPIO(GPIO.GPIOHS9,GPIO.OUT))
LS.append(GPIO(GPIO.GPIOHS10,GPIO.OUT))
LS.append(GPIO(GPIO.GPIOHS15,GPIO.OUT))
LS.append(GPIO(GPIO.GPIOHS16,GPIO.OUT))
LS.append(GPIO(GPIO.GPIOHS17,GPIO.OUT))
LS.append(GPIO(GPIO.GPIOHS18,GPIO.OUT))
data.append(GPIO(GPIO.GPIOHS19,GPIO.OUT))
data.append(GPIO(GPIO.GPIOHS20,GPIO.OUT))
data.append(GPIO(GPIO.GPIOHS21,GPIO.OUT))
data.append(GPIO(GPIO.GPIOHS22,GPIO.OUT))
data.append(GPIO(GPIO.GPIOHS23,GPIO.OUT))
data.append(GPIO(GPIO.GPIOHS24,GPIO.OUT))
data.append(GPIO(GPIO.GPIOHS25,GPIO.OUT))
data.append(GPIO(GPIO.GPIOHS26,GPIO.OUT))
