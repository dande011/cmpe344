#ifndef MAIN_H
#define MAIN_H

#include <avr/io.h>
#include <avr/pgmspace.h>
#include <avr/interrupt.h>
#include <stdlib.h>

#include "cube.h"

// Define USART stuff
#define FOSC 16000000
#define BAUD 38400
#define MYUBRR (((((FOSC * 10) / (16L * BAUD)) + 5) / 10) - 1)

#define DATA_BUS PORTA
#define LAYER_SELECT PORTC
#define LATCH_ADDR PORTB
#define LATCH_MASK 0x07
#define LATCH_MASK_INV 0xf8
#define OE_PORT PORTB
#define OE_MASK 0x08
#define MUSIC_PORT PORTD
#define MUSIC_MASK 0xc0 // bits 6 and 7 of port D
#define MUSIC_MASK_INV 0x3f // not bits 6 and 7 on port D

// Red led on D2
#define LED_RED 0x04
// Green led D3
#define LED_GREEN 0x08
// Program led on D4
#define LED_PGM 0x10;
// Leds connected to port D
#define LED_PORT PORTD
// Rs232 button on D5
#define RS232_BTN 0x20
// Main button on B4
#define MAIN_BTN 0x10 
// Music Mode Button on D7
#define MUSIC_BTN 0x40
// Music mode beat input on D6
#define MUSIC_BEAT 0x80
// Music port is also port D
#define MUSIC_PORT PORTD

void ioinit (void);
void bootmsg (void);
void selftest (void);

volatile unsigned char current_layer;
volatile unsigned char pgm_mode;
void rs232(void);
unsigned int bootwait (void);
#endif

