# Hello World Example
#
# Welcome to the MaixPy IDE!
# 1. Conenct board to computer
# 2. Select board at the top of MaixPy IDE: `tools->Select Board`
# 3. Click the connect buttion below to connect board
# 4. Click on the green run arrow button below to run the script!
print()

addr[0].value(0)
addr[1].value(0)
addr[2].value(0)

print("oe: ",oe)
print("b: ",oe.value())
oe.value(0 )
print("a: ",oe.value())

for i in LS:
    print("b: ",i.value())
    i.value(1)
    print("a: ",i.value())
for i in data:
    i.value(1)
