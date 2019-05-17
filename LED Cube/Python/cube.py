def validVoxel(x,y,z):
    if not(x <= CUBESIZE):
        return False
    elif not(y <= CUBESIZE):
        return False
    elif not(z <= CUBESIZE):
        return False
    else:
        return True

def setAddress(x,val):
    a = not val
    b = not val
    c = not val
    if x == 0:
        """nothing"""
    elif x == 1:
        c = val
    elif x == 2:
        b = val
    elif x == 3:
        b = val
        c = val
    elif x == 4:
        a = val
    elif x == 5:
        a = val
        c = val
    elif x == 6:
        a = val
        b = val
    elif x == 7:
        a = val
        b = val
        c = val
    oe.value(0)
    addr[0].value(a)
    addr[1].value(b)
    addr[2].value(c)

    addr[0].value(0)
    addr[1].value(0)
    addr[2].value(0)

    if(x == 0):
        addr[0].value(0)
        addr[1].value(0)
        addr[2].value(1)


def setVoxel(x,y,z,val):
    if not validVoxel(x,y,z):
        print("Check Voxel Failed")
        return -1
    oe.value(1)

    print("data[",y,"].value(",val,")")
    data[y].value(val)

    print("setAddress(",x,",",val,")")
    setAddress(x,val)

    print("LS[",z,"].value(",val,")")
    LS[z].value(val)

def zero():
    for i in data:
        i.value(0)
    """for j in range(0,8):
        print(j)
        setAddress(j,0)"""
    setAddress(0,0)
    for k in LS:
        k.value(0)


