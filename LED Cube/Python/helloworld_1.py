# Hello World Example
#
# Welcome to the MaixPy IDE!
# 1. Conenct board to computer
# 2. Select board at the top of MaixPy IDE: `tools->Select Board`
# 3. Click the connect buttion below to connect board
# 4. Click on the green run arrow button below to run the script!

import utime

from Maix import GPIO

fm.register(board_info.LED_R, fm.fpioa.GPIO0)
fm.register(27,fm.fpioa.GPIOHS1)
fm.register(28,fm.fpioa.GPIOHS2)
fm.register(29,fm.fpioa.GPIOHS3)




led_r=GPIO(GPIO.GPIO0,GPIO.OUT)
out1=GPIO(GPIO.GPIOHS1,GPIO.OUT)
out2=GPIO(GPIO.GPIOHS2,GPIO.OUT)
out3=GPIO(GPIO.GPIOHS3,GPIO.OUT)



case = 0
while case<60:
    out1.value(not (case)%3)
    out2.value(not (case+1)%3)
    out3.value(not (case+2)%3)
    case += 1
    utime.sleep_ms(500)

print("out1: ",out1)
print(out1.value())
led_r.value(1)
out1.value(0)
out2.value(0)
out3.value(0)
