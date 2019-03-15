#include "launch_effect.h"
#include "effect.h"
#include "draw.h"
#include "gameoflife.h"
extern int xit;
void launch_effect (int effect)
{


int i;
    unsigned char ii;
	int x = 0;
	fill(0x00);
	LED_PORT &= (0xE3); // turn off status and diag LED
	switch (effect)
	{
		case 0:
			fill(0x00);
            // Create a random starting point for the Game of Life effect.
			for (i = 0; i < 20;i++)
			{
				setvoxel(rand()%4,rand()%4,rand()%4);
			}
	
			gol_play(50, 600);
			break;
		case 1:
		for (i=6;i<13;i++)
		{
	effect_smileyspin(3,1000,i);
			}
while (xit == 1) {delay_ms (500);}

			effect_blinky2();
while (xit == 1) {delay_ms (500);}

			effect_rain(100);
while (xit == 1) {delay_ms (500);}
			fill(0x00);
			for (i=15;i>1;i--){
int_ripples(64,30*i);
// if (xit == 1) {i=1;}
}
while (xit == 1) {delay_ms (500);}
			break;
		
		case 2:
			
			effect_path_text(1000,"8X8X8    3D   LED   CUBE");
			effect_stringfly2("BY");
			effect_path_text(1000,"Yarin Levy");
			effect_path_text(1000,"With Thanks to:");
			effect_path_text(1000,"Ort Rehovot   &   Norman At SUPERTECH-IT DOT COM");
			
			// sidewaves(2000,100);
			linespin(1500,20);
while (xit == 1) {delay_ms (500);}
			sinelines(4000,10);
while (xit == 1) {delay_ms (500);}

			// spheremove(3000,10);
			
			// twister (8,600);
			// effect_pathspiral (64,600);
			
fill (0x00);
			effect_path_bitmap (1200,12,3);
if (xit == 1) {goto skipfish;}
			effect_path_bitmap (900,12,3);
if (xit == 1) {goto skipfish;}
			effect_path_bitmap (600,12,3);
if (xit == 1) {goto skipfish;}
			effect_path_bitmap (300,12,3);
if (xit == 1) {goto skipfish;}
			effect_path_bitmap (100,12,3);
if (xit == 1) {goto skipfish;}
			effect_path_bitmap (10,12,3);
skipfish:
while (xit == 1) {delay_ms (500);}
			squarespiral (300, 500);
while (xit == 1) {delay_ms (500);}
			squarespiral2 (200, 900);
while (xit == 1) {delay_ms (500);}
			side_ripples (300, 500);
while (xit == 1) {delay_ms (500);}
			quad_ripples (600,300);
while (xit == 1) {delay_ms (500);}
			break;

		case 3:
			effect_path_bitmap (700,6,4);
while (xit == 1) {delay_ms (500);}
// effect_stringfly2 ("THE END");
			break;

		case 4:
			sendvoxels_rand_z(20,220,2000);
while (xit == 1) {delay_ms (500);}
			break;
				
		case 5:
			effect_random_filler(5,1);
if (xit == 1) {goto skipfiller;}
			effect_random_filler(5,0);
if (xit == 1) {goto skipfiller;}
			effect_random_filler(5,1);
if (xit == 1) {goto skipfiller;}
			effect_random_filler(5,0);
skipfiller:
while (xit == 1) {delay_ms (500);}
			break;
				
		case 6:
			effect_z_updown(20,1000);
while (xit == 1) {delay_ms (500);}
			break;
				
		case 7:
			effect_wormsqueeze (2, AXIS_Z, -1, 100, 1000);
while (xit == 1) {delay_ms (500);}
			break;
				
		case 8:
			effect_blinky2();
while (xit == 1) {delay_ms (500);}
			break;
		case 9:
			mirror_ripples(600,400);
while (xit == 1) {delay_ms (500);}				
		case 10: 
            for (ii=0;ii<8;ii++)
			{
				effect_box_shrink_grow (1, ii%4, ii & 0x04, 450);
			}
if (xit == 1) {goto skipwoop;}
			effect_box_woopwoop(800,0);
			if (xit == 1) {goto skipwoop;}
			effect_box_woopwoop(800,1);
			if (xit == 1) {goto skipwoop;}
			effect_box_woopwoop(800,0);
			if (xit == 1) {goto skipwoop;}
			effect_box_woopwoop(800,1);
skipwoop:
while (xit == 1) {delay_ms (500);}
			break;
			
		case 11:
			effect_planboing2 (AXIS_Z, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing2 (AXIS_X, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing2 (AXIS_Y, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing2 (AXIS_Z, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing2 (AXIS_X, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing2 (AXIS_Y, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing (AXIS_Z, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing (AXIS_X, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing (AXIS_Y, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing (AXIS_Z, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing (AXIS_X, 600);
if (xit == 1) {goto skipboing;}
			effect_planboing (AXIS_Y, 600);
skipboing:
while (xit == 1) {delay_ms (500);}
			fill(0x00);
			break;
		
		case 12:
			fill(0x00);
			effect_telcstairs(0,800,0xff);
			effect_telcstairs(0,800,0x00);
			effect_telcstairs(1,800,0xff);
			effect_telcstairs(1,800,0x00);
			break;
			
		case 13:
			effect_axis_updown_randsuspend(AXIS_Z, 550,5000,0);
if (xit == 1) {goto skipdown;}
			effect_axis_updown_randsuspend(AXIS_Z, 550,5000,1);
if (xit == 1) {goto skipdown;}
			effect_axis_updown_randsuspend(AXIS_Z, 550,5000,0);
if (xit == 1) {goto skipdown;}
			effect_axis_updown_randsuspend(AXIS_Z, 550,5000,1);
if (xit == 1) {goto skipdown;}
			effect_axis_updown_randsuspend(AXIS_X, 550,5000,0);
if (xit == 1) {goto skipdown;}
			effect_axis_updown_randsuspend(AXIS_X, 550,5000,1);
if (xit == 1) {goto skipdown;}
			effect_axis_updown_randsuspend(AXIS_Y, 550,5000,0);
if (xit == 1) {goto skipdown;}
			effect_axis_updown_randsuspend(AXIS_Y, 550,5000,1);
skipdown:
while (xit == 1) {delay_ms (500);}
			break;
			
		case 14:
			effect_loadbar(700);
while (xit == 1) {delay_ms (500);}
			break;
			
		case 15:
			effect_wormsqueeze (1, AXIS_Z, 1, 100, 1000);
while (xit == 1) {delay_ms (500);}
			break;
			
			
		case 16:
			effect_stringfly2("SUPERTECH-IT DOT COM    SUPERTECH-IT DOT COM");
while (xit == 1) {delay_ms (500);}
			break;
			
					
		case 17:
			effect_boxside_randsend_parallel (AXIS_Z, 0 , 200,1);
			delay_ms(1500);
			effect_boxside_randsend_parallel (AXIS_Z, 1 , 200,1);
			delay_ms(1500);
			
			effect_boxside_randsend_parallel (AXIS_Z, 0 , 200,2);
			delay_ms(1500);
			effect_boxside_randsend_parallel (AXIS_Z, 1 , 200,2);
			delay_ms(1500);
			
			effect_boxside_randsend_parallel (AXIS_Y, 0 , 200,1);
			delay_ms(1500);
			effect_boxside_randsend_parallel (AXIS_Y, 1 , 200,1);
			delay_ms(1500);
			break;
			
		case 18:
			boingboing(250, 600, 0x01, 0x02);
while (xit == 1) {delay_ms (500);}
			break;
			
		case 19:
for (i=7;i<9;i++){
	effect_smileyspin(4,1000,x);
if (xit == 1) {i=9;}

			}
while (xit == 1) {delay_ms (500);}

			break;
			
		case 20:
			effect_pathspiral(200,500);
while (xit == 1) {delay_ms (500);}
			break;
			
		case 21:
			effect_path_bitmap(700,2,3);
while (xit == 1) {delay_ms (500);}
			break;
			
		case 22:
			effect_smileyspin(2,1000,1);
while (xit == 1) {delay_ms (500);}
			break;
			
		case 23:
			effect_path_text(1000,"SUPERTECH-IT DOT COM  SUPERTECH-IT DOT COM");
			// effect_path_text(1000,"LED    CUBE");
			// effect_path_text(1000,"LED    CUBE");
while (xit == 1) {delay_ms (500);}
			break;
	
		case 24:
			effect_rand_patharound(200,500);
while (xit == 1) {delay_ms (500);}
			break;
			
		case 25:
			//effect_wormsqueeze (1, AXIS_Z, -1, 100, 1000);
			effect_blinky2();
while (xit == 1) {delay_ms (500);}
			break;
			
		case 26:
			effect_smileyspin(2,1000,2);
while (xit == 1) {delay_ms (500);}
			break;
			
		case 27:
			effect_random_sparkle();
while (xit == 1) {delay_ms (500);}
			break;
			
		case 28:
			effect_wormsqueeze (1, AXIS_Z, -1, 100, 1000);
while (xit == 1) {delay_ms (500);}
			break;
		
		case 29:
			boingboing(250, 600, 0x01, 0x03);
while (xit == 1) {delay_ms (500);}
			break;
		
		case 30:
			effect_filip_filop(100);
while (xit == 1) {delay_ms (500);}
			break;
			
		case 31:
		    int_ripples(600,300);
while (xit == 1) {delay_ms (500);}
			mirror_ripples (600,300);
while (xit == 1) {delay_ms (500);}
			side_ripples (600,300);
while (xit == 1) {delay_ms (500);}
			quad_ripples (100,2000);
while (xit == 1) {delay_ms (500);}
			break;

		case 32:
			int_sidewaves(800,25);
while (xit == 1) {delay_ms (500);}
			break;
			
		case 33:
			// effect_cubix(100,1);
			// effect_cubix(100,2);
			effect_cubix(100,3);
while (xit == 1) {delay_ms (500);}
			break;
		case 34:
			fireworks(10,30);
while (xit == 1) {delay_ms (500);}
			break;
		case 35:
			fill(0x00);
			for (i = 0; i < 10;i++)
			{
				setvoxel(rand()%4+2,rand()%4+2,rand()%4+2);
			}
	
			gol_play(200, 700);
			fill(0x00);
			break;
		// In case the effect number is out of range:
		default:
			effect_stringfly2("FAIL");
			break;

	}
}

