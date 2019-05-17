# Hello World Example
#
# Welcome to the MaixPy IDE!
# 1. Conenct board to computer
# 2. Select board at the top of MaixPy IDE: `tools->Select Board`
# 3. Click the connect buttion below to connect board
# 4. Click on the green run arrow button below to run the script!
print()


#def run():
oe.value(0)
oe.value(1)

for i in range(0,8):
    utime.sleep_ms(500)
    #zero()
    setVoxel(i,i,i,1)
    utime.sleep_ms(500)
    #zero()

#setAddress(3,1)
#data[1].value(1)
#LS[6].value(1)


utime.sleep_ms(500)
zero()
utime.sleep_ms(500)
oe.value(1)




