import nes
from Maix import GPIO

fm.register(8,  fm.fpioa.GPIO0)
wifi_en=GPIO(GPIO.GPIO0,GPIO.OUT)
wifi_en.value(0)

nes.init(0)
nes.run("smb3.nes")