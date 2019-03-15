Init_AVR should be used when first initializing a new ATmega32 AVR for the first time, OR if your fuse bits get messed up.

Flash_AVR is used to transfer the demo code to the ATmega32 microcontroller.

BOTH of the above programs require connection to a USBTiny or USBasp AVR ICSP programmer. It doesn't work (to my knowledge) with others, and does not work on X64 Windows.

If you are using an ATmega328P, then you can use the Arduino IDE to transfer code directly to the cube using the file>Upload Using Programmer option from the menu if you are using an ICSP programmer, or you can program the chip in your UNO and then put it on the Black Edition board.

The spectrum analyser program is written in PROCESSING - if you want to change the com port or anything like that, then make the changes in the source code and recompile it.

If you don't know how to do that, then simply assign your TTL Serial interface to COM1: in Windows.

The CUBO utility usually needs to have the com port set before it starts to behave, and it can be a bit erratic up to that point, but usually works fine once it's set. You need Java to run this.

USE OF ANY PC BASED cube control software assumes you have a TTL SERIAL interface, not an RS232 serial because the interface on the board is TTL Serial.

The TTL SERIAL inputs from these programs also assumes the ATmega32A processor. They will NOT work with the Arduino ATmega328P processor on the board.

NEVER put BOTH processors on the board! Use one or the other.

I do not necessarily support any of the free bonus software.