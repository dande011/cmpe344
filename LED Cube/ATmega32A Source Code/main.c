/*
 * Code to control an 8x8x8 ledcube using avr
 * http://www.instructables.com/id/Led-Cube-8x8x8/
 * See licence.txt for licence.
 * Power On Self Test Dagnostic, additional characters and effect modifications by SuperTech-IT.
 */
#include "main.h"
#include "effect.h"
#include "launch_effect.h"
#include "draw.h"
#include <tottymath.h>
#include <math.h>




int selftestDelay = 500;
int x;
int y;
int z;
int seed = 1;
int wave;
int xit;
int i;

// selftest;
//void selftest (void);
int n = 0;
int m = 0;


// Main loop
// the AVR enters this function at boot time
int main (void)
{
	// This function initiates IO ports, timers, interrupts and
    // serial communications
	 ioinit(); 
sei();
selftest();

    // This variable specifies which layer is currently being drawn by the
	// cube interrupt routine. We assign a value to it to make sure it's not >7.
	current_layer = 1; 	

		
	// Boot wait
	// This function serves 3 purposes
	// 1) We delay starting up any interrupts, as drawing the cube causes a lot
	//    noise that can confuse the ISP programmer.
	// 2) Listen for button press. One button means go into rs232 mode,
	//    The other means go into autonomous mode and start doing stuff.
	// 3) Random seed. The bootwait function counts forever from 0 to 255.
	//    Whenever you press the button, this counter stops, and the number it
	//    stopped at is used as a random seed. This ensures true randomness at
	//    every boot. Without this (or some similar process) the cube would
	//    produce the same "random" sequence every time
	int i;

	i = bootwait(); 


	// Enable interrupts
	// This starts the routine that draws the cube content

	 // sei();
// Result for bootwait is 3 - enter Music mode
	if (i == 3)
{

//*************************************************************
// Music mode start
//************************************************************* 

int updownspeed = 150;
fill (0x00);
while (xit == 1) {delay_ms (500);}
effect_stringfly2 ("MUSIC");
LED_PORT = 0x00; // Turn off all LEDs, set other bits floating
PORTD |= 0x40; // Turn on pullup for Music Mode button
{
fill (0x00);
while (1)
// PORTD PORTD ^= 0b01000000;
{

//*************************************************************
// Music routine 1
//*************************************************************
int boombox,ii;
int long collapseDelay = 100000;
fill (0x00);
while (xit == 1) {delay_ms (500);} //wait for music button release
effect_stringfly2 ("1");

boombox = 0;

while (xit == 0)
	{

 if ((PIND & MUSIC_BEAT) && (boombox < 3)) {boombox ++;collapseDelay = 100000;}

while ((!(PIND & MUSIC_BEAT)) && (collapseDelay > 0))
{collapseDelay --;}
 if ((collapseDelay < 1) && (boombox > 0)) {collapseDelay = 100000; boombox --;fill(0x00);} // shink by 1 box
	
		ii = boombox;
		if (boombox > 0) {fill (0x00);} // removes last box by clearing cube - but not if there is no signal - this prevents flickering.	
		box_wireframe(4+ii,4+ii,4+ii,3-ii,3-ii,3-ii);
		// box_filled(4+ii,4+ii,4+ii,3-ii,3-ii,3-ii);
		
	}




//*************************************************************
// Music routine 2
//*************************************************************
fill (0x00);
while (xit == 1) {delay_ms (500);}
effect_stringfly2 ("2");	

LUT_START // Macro
	unsigned char now_plane=0;//start at top
	unsigned char next_plane;
	int delay=200;
	while(PIND & MUSIC_BTN)
	{
while (!(PIND & MUSIC_BEAT) && (PIND & MUSIC_BTN))
		{
if (!(PIND & MUSIC_BTN)) {break;}//notify loop of button press
		}
if (!(PIND & MUSIC_BTN)) {break;}//notify loop of button press

		next_plane=rand()%6; //0-5
		// Check that not the same, and that:
		// 0/1 2/3 4/5 pairs do not exist.
		if ((next_plane&0x06)==(now_plane&0x06))
			next_plane=(next_plane+3)%6;
		effect_plane_flip(LUT,now_plane,next_plane,delay);
		now_plane=next_plane;
if (!(PIND & MUSIC_BTN)) {break;}//notify loop of button press


	}
//*************************************************************
// Music routine 3
//*************************************************************

i = i;
fill (0x00);
while (xit == 1) {delay_ms (500);}
effect_stringfly2 ("3");
while (PIND & MUSIC_BTN)  // run until MUSIC button pressed

// LED_PORT ^= LED_PGM; // change state of diag LED 
// PORTD = ( 0 << PD4 );
	{
		{
i = (rand()%9);
pillar (0,0,i);
i = (rand()%9);
pillar (0,4,i);
i = (rand()%9);
pillar (2,2,i);
i = (rand()%9);
pillar (2,6,i);
i = (rand()%9);
pillar (4,0,i);
i = (rand()%9);
pillar (4,4,i);
i = (rand()%9);
pillar (6,2,i);
i = (rand()%9);
pillar (6,6,i);

//}
//delay_ms(500);
//}
// PORTD = ( 1 << PD4 );
for (z=0;z<7;z++)
			{

while ((!(PIND & MUSIC_BEAT)) && (i<20001)) // no beat or button, drop bars
// LED_PORT &= ~LED_PGM// turn off beat LED
// PORTD == (PIND & 11111111);
				{
delay_ms (100);
shift (AXIS_Z, -1);
// shift (AXIS_X, 1);
//delay_ms (1000);
i=1;
while (i<20000)
					{
i++;
if ((PIND & MUSIC_BEAT))	{
i=20000;
					}
if (!(PIND & MUSIC_BTN)) {i=20001;}//notify loop of button press
				}
// fill (0x00);
			}
		}
	}
}

//*************************************************************
// Music routine 4
//*************************************************************

fill (0x00);
i = 1;
while (xit == 1) {delay_ms (500);}
effect_stringfly2 ("4");
while(PIND & MUSIC_BTN)
	{

for (x=0;x<8;x++)
		{
y = (rand()%9);
wall (x,y);
		}
while ((!(PIND & MUSIC_BEAT)) && (i<20001)) // no beat or button, drop bars
		{
delay_ms (100);
shift (AXIS_Z, -1);
// shift (AXIS_X, 1);
//delay_ms (1000);
i=1;
while (i<20000)
		{
i++;
if ((PIND & MUSIC_BEAT))	{
i=20000;
					}
if (!(PIND & MUSIC_BTN)) {i=20001;}//notify loop of button press
		}
	}
}
//*************************************************************
// Music routine 5
//*************************************************************

i = 1;
fill (0x00);
while (xit == 1) {delay_ms (500);}
effect_stringfly2 ("5");
while ((PIND & MUSIC_BTN))

{

	unsigned char positions[64];
	unsigned char destinations[64];

	int i,y,move;
	
	for (i=0; i<64; i++)
	{
		positions[i] = 4;
		destinations[i] = rand()%8;
	}

	for (i=0; i<8; i++)
	{
		effect_z_updown_move(positions, destinations, AXIS_Z);
		delay_ms(updownspeed);
	}
	
	// for (i=0;i<iterations;i++)
while (!(PIND & MUSIC_BEAT))
	{
		for (move=0;move<8;move++)
		{
			effect_z_updown_move(positions, destinations, AXIS_Z);
			delay_ms(updownspeed);
		}

	while (!(PIND & MUSIC_BEAT))
		{
if (!(PIND & MUSIC_BTN)) {break;}//notify loop of button press
		}


		for (y=0;y<32;y++)
		{
				destinations[rand()%64] = rand()%8;
		}
	if (!(PIND & MUSIC_BTN)) {break;}//notify loop of button press	
	}
if (!(PIND & MUSIC_BTN)) {break;}//notify loop of button press
}


//*************************************************************
// Music routine 6
//*************************************************************

fill (0x00);
i = 1;
x = (rand()%9);
y = (rand()%9);
z = (rand()%9);
while (xit == 1) {delay_ms (500);}
effect_stringfly2 ("6");
while(PIND & MUSIC_BTN)
	{
x = (rand()%9);
y = (rand()%9);
z = (rand()%9);
setvoxel (x,y,z);  
// wave = (rand()%9);
// delay_ms (100);		
while ((!(PIND & MUSIC_BEAT)) && (i<20001)) 
		{
x = (rand()%9);
y = (rand()%9);
z = (rand()%9);
clrvoxel (x,y,z);  


i=1;
while (i<2000)
		{
i++;
if ((PIND & MUSIC_BEAT))	{
i=2000;
					}
if (!(PIND & MUSIC_BTN)) {i=20001;}//notify loop of button press
		}
	}
}

//*************************************************************
// Music routine 7
//*************************************************************

int i = 1;
fill (0x00);
while (xit == 1) {delay_ms (500);}

effect_stringfly2 ("7");
while (PIND & MUSIC_BTN) // run until MUSIC button pressed
	{
for (x=0; x<8; x++)
		{
for (y=0; y<8; y++)
			{
i = (rand()%9);
spike(x,y,i);
			}
//delay_ms(500);
		}
// PORTD = ( 1 << PD4 );
for (z=0;z<7;z++)
		{

while ((!(PIND & MUSIC_BEAT)) & (i<20001)) // no beat or button - drop bars
			{
delay_ms (100);
shift (AXIS_Z, -1);
// shift (AXIS_X, 1);
//delay_ms (1000);
i=1;
while (i<20000)
				{
i++;
if (PIND & MUSIC_BEAT) // if beat while falling, end delay
					{
i=20000;
					}
if (!(PIND & MUSIC_BTN)) {i=20001;}//notify loop of button press
				}
// fill (0x00);
			}
		}
	}


//*************************************************************
// Music routine end
//*************************************************************

}
}
}

//*************************************************************
// Music mode end
//************************************************************* 
	
	// Result for bootwait() is 2:
	// Go to rs232 mode. this function loops forever.
	if (i == 2)
	{
		fill (0x00); // clear any self test remainder off the screen
		effect_stringfly2 ("TTL SERIAL");
		fill (0X00); // clear the cube
LED_PORT &= ~LED_PGM; // turn off the diag LED
		rs232(); 
	}

	// Result of bootwait() is something other than 2 or 3:
	// Do awesome effects. Loop forever.

while (1)
	{
// EFFECTS_TOTAL = 2; // was here for testing
	// Show the effects in a predefined order
		for (i=1;  i<EFFECTS_TOTAL;  i++)
		{

launch_effect(i);
	
if (xit == 1) {} // if the button is down, wait til it's not 
		}
		// Show the effects in a random order.
		// Comment the two lines above and uncomment this
		// if you want the effects in a random order.
		//launch_effect(rand()%EFFECTS_TOTAL); 
	}

}

/*
 * De-Multiplexer/framebuffer routine
 * This function is called by an interrupt generated by timer 2.
 * Every time it runs, it does the following:
 * 1) Disable the output for the multiplexer array.
 * 2) Turn of all layers.
 * 3) Load the current layer from the cube buffer onto the
 *    multiplexer array.
 * 4) Enable output from the multiplexer array.
 * 5) Turn on the current layer.
 * 6) Increment the current_layer variable, so the next layer is
 *    drawn the next time this function runs.
*/

ISR(TIMER2_COMP_vect)
{
int i;

	LAYER_SELECT = 0x00;  // Turn all cathode layers off. (all transistors off)
	OE_PORT |= OE_MASK;  // Set OE high, disabling all outputs on latch array
xit = 0;
xit = (!(PIND & MUSIC_BTN)); // see if button to exit animation pressed

	// Loop through all 8 bytes of data in the current layer
	// and latch it onto the cube.
	for (i = 0;  i < 8;  i++)
	{
		// Set the data on the data-bus of the latch array.
		PORTA = cube[current_layer][i]; 
		// Increment the latch address chip, 74HC138, to create
		// a rising edge (LOW to HIGH) on the current latch.
		LATCH_ADDR = (LATCH_ADDR & LATCH_MASK_INV) | (LATCH_MASK & (i+1)); 
	}

	OE_PORT &= ~OE_MASK;  // Set OE low, enabling outputs on the latch array
	LAYER_SELECT = (0x01 << current_layer);  // Transistor ON for current layer

	// Increment the curren_layer counter so that the next layer is
	// drawn the next time this function runs.
	current_layer++; 
	// We want to count from 0-7, so set it to 0 when it reaches 8.
	if (current_layer == 8)
		current_layer = 0; 

}


void ioinit (void)
{
	DDRA = 0xff; 	// DATA bus output
	DDRB = 0xef; 	// Button on B4
	DDRC = 0xff; 	// Layer select output
	// DDRD = 0xdf; 	// Button on D5
	DDRD = 0x1f;    // Button on D5 and D6 and music on D7
	
	PORTA = 0x00;  // Set data bus off
	PORTC = 0x00;  // Set layer select off
	PORTB = 0x10;  // Enable pull up on button.
	PORTD = 0x60;  // Enable pull up on button + music select.

	// Timer 2
	// Frame buffer interrupt
	// 14745600/128/11 = 10472.72 interrupts per second
	// 10472.72/8 = 1309 frames per second
	OCR2 = 20;  	// interrupt at counter = 10
    TCCR2 |= (1 << CS20) | (1 << CS22);  // Prescaler = 128.
	TCCR2 |= (1 << WGM21);  // CTC mode. Reset counter when OCR2 is reached.
	TCNT2 = 0x00; 	// initial counter value = 0; 
	TIMSK |= (1 << OCIE2);  // Enable CTC interrupt



    // Initiate RS232
    // USART Baud rate is defined in MYUBRR
    UBRRH = MYUBRR >> 8; 
    UBRRL = MYUBRR; 
    // UCSRC - USART control register
    // bit 7-6      sync/ascyn 00 = async,  01 = sync
    // bit 5-4      parity 00 = disabled
    // bit 3        stop bits 0 = 1 bit  1 = 2 bits
    // bit 2-1      frame length 11 = 8
    // bit 0        clock polarity = 0
    UCSRC  = 0b10000110; 
    // Enable RS232, tx and rx
    UCSRB = (1<<RXEN)|(1<<TXEN); 
    UDR = 0x00;  // send an empty byte to indicate powerup.


}

// Boot wait function
// This function does 3 things:
// 1) Delay startup of interrupt. I've had some problems with in circuit
//    serial programming when the cube was running. I guess switching all
//    those LEDs on and off generates some noise.
// 2) Set a random random seed based on the delay between boot time and
//    the time you press a button.
// 3) Select mode of operation, autonomous or rs232 controlled.
unsigned int bootwait (void)

{
	// All the LED_PORT... code blinks the red and green status LEDs.

	unsigned int x = seed; 
	LED_PORT |= LED_GREEN; 
	while (1)
	{
        x++;  // increment x by one.
		srand(x);  // use counter x as random seed
		
		delay_ms(1000); 
		LED_PORT &= ~LED_GREEN;  // green off, red on
		LED_PORT |= LED_RED; 
		// LED_PORT != LED_RED;
		// Listen for button presses and return with the
		// apropriate number.
		if (!(PIND & RS232_BTN))
			return 2; 

		if (!(PINB & MAIN_BTN))
			return 1; 

		if (!(PIND & MUSIC_BTN))
			return 3; 

		if (x >= seed+200) {return 1;} // start the patterns if buttons are ignored too long

		delay_ms(1000); 
		LED_PORT &= ~LED_RED;  // red off, green on
		LED_PORT |= LED_GREEN; 
		
		// Same as above. I do it twice because there are two delays
		// in this loop, used for the red and green led blinking..
		if (!(PIND & RS232_BTN))
			return 2; 

		if (!(PINB & MAIN_BTN))
			return 1; 

		if (!(PIND & MUSIC_BTN))
 			return 3; 
	}
}

// Take input from a computer and load it onto the cube buffer
void rs232(void)
{
	int tempval; 
	int x = 0; 
	int y = 0; 
    int escape = 0; 
	
	while (1)
	{
		// Switch state on red LED for debugging
		// Should switch state every time the code
		// is waiting for a byte to be received.
		LED_PORT ^= LED_RED; 

		// Wait until a byte has been received
		while ( !(UCSRA & (1<<RXC)) ); 

		// Load the received byte from rs232 into a buffer.
		tempval = UDR; 

		// Uncommet this to echo data back to the computer
		// for debugging purposes.
		//UDR = tempval; 

		// Every time the cube receives a 0xff byte,
		// it goes into sync escape mode.
		// if a 0x00 byte is then received, the x and y counters
		// are reset to 0. This way the x and y counters are
		// always the same on the computer and in the cube.
		// To send an 0xff byte, you have to send it twice!

		// Go into sync escape mode
		if (tempval == 0xff)
		{
			// Wait for the next byte
			 while ( !(UCSRA & (1<<RXC)) ); 
			 // Get the next byte
			 tempval = UDR; 

			 // Sync signal is received.
			 // Reset x and y counters to 0.
			 if (tempval == 0x00)
			 {
				x = 0; 
				y = 0; 
                escape = 1; 
			 }
			 // if no 0x00 byte is received, proceed with
			 // the byte we just received.
		}

        if (escape == 0)
        {
		// Load data into the current position in the buffer
		fb[x][y] = tempval; 

    		// Check if we have reached the limits of the buffer array.
    		if (y == 7)
    		{
    			if (x == 7)
    			{
    				// All data is loaded. Reset both counters
    				y = 0; 
    				x = 0; 
                    // Copy the data onto the cube.
    				tmp2cube(); 
    			} else
    			{
    				// A layer is loaded, reset y and increment x.
    				x++; 
    				y = 0; 
    			}
    		} else
    		{
    			// We are in the middle of loading a layer. increment y.
    			y++; 
    		}
	
	    } else
        {
            escape = 0; 
        }
    }
 }


void USART_send( unsigned char data){
 
 //while(!(UCSRA & (1<<TXC)));
while(!(UCSRA & (1<<UDRE)));
 UDR = data;
 
}
void Serprint(char* StringPtr){
// int i; 
// while(*StringPtr != 0x00){    //Here we check if there is still more chars to send, this is done checking the actual char and see if it is different from the null char
while(*StringPtr != i){    //Here we check if there is still more chars to send, this is done checking the actual char and see if it is different from the null char
 USART_send(*StringPtr);    //Using the simple send function we send one char at a time
 StringPtr++;}        //We increment the pointer so we can read the next char
 
}

void selftest (void)

{
// LED_PORT != LED_RED + LED_GREEN + LED_PGM; // turn off all LEDs
for (y=0; y<8; y++){
for (x=0; x<8; x++){
LED_PORT ^= LED_PGM; // change state of diag LED
for (z=0; z<8; z++){

setvoxel (x,y,z); 
}

for (m=0;m<selftestDelay*2;m++)
{
seed ++;

if (!(PINB & MAIN_BTN))
			return;
if (!(PIND & RS232_BTN))
			return;
if (!(PIND & MUSIC_BTN))
			return; 
for (n=0; n<selftestDelay; n++)
{
}
}
for (z=0; z<8; z++){
clrvoxel (x,y,z); 
}
}}

for (z=0; z<8; z++){
for (y=0; y<8; y++){
LED_PORT ^= LED_PGM; // change state of status LED
for (x=0; x<8; x++){

setvoxel (x,y,z);

 
for (m=0;m<selftestDelay/4;m++)
{
seed ++; // seed for random in case diagnostic interrupted by run button.

if (!(PINB & MAIN_BTN))
			return;
if (!(PIND & RS232_BTN))
			return;
if (!(PIND & MUSIC_BTN)) 
			return; 
for (n=0; n<selftestDelay/4; n++)
{
}
}



}}}

//for (z=0; z<8; z++){
//for (y=0; y<8; y++){
//for (x=0; x<8; x++){

//clrvoxel (x,y,z); 
//for (m=0;m<selftestDelay;m++)
//{
//for (n=0; n<selftestDelay; n++)
//{
//}
//}


//}}}
LED_PORT &= ~LED_PGM; // turn off diag LED

}
