#include "effect.h"
#include "draw.h"
#include "draw_3d.h"
#include "3d.h"
#define FF_DELAY 500 
#include "font.h"
#include <math.h>
#include <avr/interrupt.h>
#include <math.h>
#include <tottymath.h>
#include <stdlib.h>
#include <stdint.h>
#include <stdio.h>
#include <string.h>
extern int xit;


// *************************************
// Trying to add some effects here...
// *************************************

void wall (x,y) // make a "wall" at position X, Y high
{
int w;
int z;

for (z=0;z < y;z++)
{
for (w=0;w < 8;w++)
{
setvoxel (w,x,z);
}
}
}

void pillar (x,y,z)
	{
int i;
for (i=0;i<z;i++)
		{
setvoxel (x,y,i);
setvoxel (x+1,y,i);
setvoxel (x,y+1,i);
setvoxel (x+1,y+1,i);
		}
	}


void spike(x,y,z)
	{
int i;
for (i=0;i<z;i++)
		{
		setvoxel (x,y,i);
		}
	}
	
void linespin (int iterations, int delay)
{
	float top_x, top_y, top_z, bot_x, bot_y, bot_z, sin_base;
	float center_x, center_y;
	
	center_x = 4;
	center_y = 4;

	int i, z;
	for (i=0;i<iterations;i++)

	{
if (xit == 1) {i = iterations;goto skipspin;}
		//printf("Sin base %f \n",sin_base);

		for (z = 0; z < 8; z++)
		{
if (xit == 1) {i = iterations;goto skipspin;}

		sin_base = (float)i/50 + (float)z/(10+(7*sin((float)i/200)));

		top_x = center_x + sin(sin_base)*5;
		top_y = center_x + cos(sin_base)*5;
		//top_z = center_x + cos(sin_base/100)*2.5;

		bot_x = center_x + sin(sin_base+3.14)*10;
		bot_y = center_x + cos(sin_base+3.14)*10;
		//bot_z = 7-top_z;
		if (xit == 1) {i = iterations;goto skipspin;}
		bot_z = z;
		top_z = z;

		// setvoxel((int) top_x, (int) top_y, 7);
		// setvoxel((int) bot_x, (int) bot_y, 0);

		//printf("P1: %i %i %i P2: %i %i %i \n", (int) top_x, (int) top_y, 7, (int) bot_x, (int) bot_y, 0);

		//line_3d((int) top_x, (int) top_y, (int) top_z, (int) bot_x, (int) bot_y, (int) bot_z);
		line_3d((int) top_z, (int) top_x, (int) top_y, (int) bot_z, (int) bot_x, (int) bot_y);
if (xit == 1) {i = iterations;goto skipspin;}
		}
skipspin:
		delay_ms(1);
		fill(0x00);
if (xit == 1) {break;}
	}

}

void sinelines (int iterations, int delay)
{
	int i,x;

	float left, right, sine_base, x_dividor,ripple_height;

	for (i=0; i<iterations; i++)
// effect_stringfly2 (xit);
{
if (xit == 1) {break;}
	for (x=0; x<8 ;x++)
		{
			x_dividor = 2 + sin((float)i/100)+1;
			ripple_height = 3 + (sin((float)i/200)+1)*6;

			sine_base = (float) i/40 + (float) x/x_dividor;

			left = 4 + sin(sine_base)*ripple_height;
			right = 4 + cos(sine_base)*ripple_height;
			right = 7-left;

			//printf("%i %i \n", (int) left, (int) right);

			line_3d(0-3, x, (int) left, 7+3, x, (int) right);
			//line_3d((int) right, 7, x);
		}
	
	// delay_ms(delay);
	fill(0x00);
	}
}

// Display a sine wave running out from the center of the cube.
void ripples (int iterations, int delay)
{
	float origin_x, origin_y, distance, height, ripple_interval;
	int x,y,i;

	//fill(0x00);

	for (i=0;i<iterations;i++)
	{
if (xit == 1) {break;}		
fill (0X00);
		for (x=0;x<8;x++)
		{
			for (y=0;y<8;y++)
			{
				distance = distance2d(3.5,3.5,x,y)/9.899495*8;
				//distance = distance2d(3.5,3.5,x,y);
				ripple_interval =1.3;
				height = 4+sin(distance/ripple_interval+(float) i/50)*4;

				setvoxel(x,y,(int) height);	
			}
		}
		// delay_ms(delay);
		// fill(0x00);
	}
}

/*
//*******************************

void sidewaves (int iterations, int delay)
{
	float origin_x, origin_y, distance, height, ripple_interval;
	int x,y,i;

	fill(0x00);

	for (i=0;i<iterations;i++)
	{
if (xit == 1) {i=iterations;break;}
		origin_x = 3.5+sin((float)i/500)*4;
		origin_y = 3.5+cos((float)i/500)*4;
		
		for (x=0;x<8;x++)
		{
			for (y=0;y<8;y++)
			{
				distance = distance2d(origin_x,origin_y,x,y)/9.899495*8;
				ripple_interval =2;
				height = 4+sin(distance/ripple_interval+(float) i/50)*3.6;

				setvoxel(x,y,(int) height);
				setvoxel(x,y,(int) height);
					
			}
		}

		delay_ms(delay);
		fill(0x00);
	}
}
*/
// ******************************************
void spheremove (int iterations, int delay)
{
	
	fill(0x00);

	float origin_x, origin_y, origin_z, distance, diameter;

	origin_x = 0;
	origin_y = 3.5;
	origin_z = 3.5;

	diameter = 3;

	int x, y, z, i;

	for (i=0; i<iterations; i++)
	{
		origin_x = 3.5+sin((float)i/50)*2.5;
		origin_y = 3.5+cos((float)i/50)*2.5;
		origin_z = 3.5+cos((float)i/30)*2;

		diameter = 2+sin((float)i/150);

		fill (0X00);
		for (x=0; x<8; x++)
		{
			for (y=0; y<8; y++)
			{
				for (z=0; z<8; z++)
				{
					distance = distance3d(x,y,z, origin_x, origin_y, origin_z);
					//printf("Distance: %f \n", distance);

					if (distance>diameter && distance<diameter+1)
					{
						setvoxel(x,y,z);
					}
				}
			}
		}

		// delay_ms(delay);
		// fill(0x00);
	}

}


/*
void effect_rotate_random_pixels (int iterations, int delay, int pixels)
{
	vertex points[pixels];
	vertex rotated[pixels];

	float fy, fx, fz;
	int x,y,z;
	int i,p;

	float rot_x = 0;
	float rot_y = 0;
	float rot_z = 0;
	vertex cube_center = {3.5, 3.5, 3.5};

	for (i=0; i<pixels; i++)
	{
		x = rand()%1200-200;	
		y = rand()%1200-200;	
		z = rand()%1200-200;
		fx = (float)x/100;
		fy = (float)y/100;
		fz = (float)z/100;

		points[i].x = fx;
		points[i].y = fy;
		points[i].z = fz;

		setvoxel((int)points[i].x, (int)points[i].y, (int)points[i].z);
		delay_ms(100);
	}
	delay_ms(10000);

	for (i=0; i<iterations; i++)
	{
		rot_x = (float)i/75;
		rot_y = (float)i/150;
		rot_z = (float)i/200;

		for (p=0; p<pixels; p++)
		{
			rotated[p] = point_rotate_around_point (points[p], cube_center, rot_x, rot_y, rot_z);
		}

		fill(0x00);
		for (p=0; p<pixels; p++)
		{
			setvoxel((int)rotated[p].x, (int)rotated[p].y, (int)rotated[p].z);
		}

		delay_ms(delay);
	}

	fill(0x00);
}


*/
float distance2d (float x1, float y1, float x2, float y2)
{	
	float dist;
	dist = sqrt((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2));

	return dist;
}

float distance3d (float x1, float y1, float z1, float x2, float y2, float z2)
{	
	float dist;
	dist = sqrt((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2) + (z1-z2)*(z1-z2));

	return dist;
}


//*************************************
// Trying to add some effects here...
//*************************************




void squarespiral (int iterations, int Delay)
{
int loc = 0;
int iter = 0;
while (iter <= iterations)
{
if (xit == 1) {break;}
for (loc =0;loc < 7; loc ++)
{
if (xit == 1) {break;}
shift (AXIS_Z,-1);
setvoxel (0,loc,7);
setvoxel (loc,7,7);
setvoxel (7,7-loc,7);
setvoxel (7-loc,0,7);

delay_ms (Delay);
if (xit == 1) {break;}
iter++;
}
loc = 0;

}
}

void squarespiral2 (int iterations, int Delay)
{
int loc = 0;
int iter = 0;
while (iter <= iterations)
{
if (xit == 1) {iter = iterations;break;}
for (loc =0;loc < 7; loc ++)
	{
if (xit == 1) {break;}
		shift (AXIS_Z,-1);
		setvoxel (0,loc,7);
		setvoxel (loc,7,7);
		setvoxel (7,7-loc,7);
		setvoxel (7-loc,0,7);
		setvoxel (0,7-loc,7);
		setvoxel (7-loc,7,7);
		setvoxel (7,loc,7);
		setvoxel (loc,0,7);
		delay_ms (Delay);
		iter++;
	}
loc = 0;
}
}

void twister (int iterations, int Delay)
{
	int iter,twist;
	for (iter = 0;iter < iterations;iter++)
	{
if (xit == 1) {iter = iterations;break;}
		for (twist=0;twist<8;twist++)
		{
if (xit == 1) {break;}
			line (0,0,twist,7,0,7-twist);
			line (0,twist,0,7,7-twist,0);
			delay_ms (Delay);
			shift (AXIS_Y, 1);
			shift (AXIS_Z, -1);
			shift (AXIS_X, -1);
		}
	}
}

void fireworks (int iterations, int n)
{
	fill(0x00);

	int i,f,e;

	float origin_x = 3;
	float origin_y = 3;
	float origin_z = 3;

	int rand_y, rand_x, rand_z;

	float slowrate, gravity;

	// Particles and their position, x,y,z and their movement, dx, dy, dz
	float particles[n][6];

	for (i=0; i<iterations; i++)
	{
if (xit == 1) {i=iterations;break;}

		origin_x = rand()%4;
		origin_y = rand()%4;
		origin_z = rand()%2;
		origin_z +=5;
        origin_x +=2;
        origin_y +=2;

		// shoot a particle up in the air value was 600+500
		for (e=0;e<origin_z;e++)
		{
			setvoxel(origin_x,origin_y,e);
			delay_ms(500+500*e);
			fill(0x00);
if (xit == 1) {break;}
		}

		// Fill particle array
		for (f=0; f<n; f++)
		{
if (xit == 1) {break;}
			// Position
			particles[f][0] = origin_x;
			particles[f][1] = origin_y;
			particles[f][2] = origin_z;
			
			rand_x = rand()%200;
			rand_y = rand()%200;
			rand_z = rand()%200;

			// Movement
			particles[f][3] = 1-(float)rand_x/100; // dx
			particles[f][4] = 1-(float)rand_y/100; // dy
			particles[f][5] = 1-(float)rand_z/100; // dz
		}

		// explode
		for (e=0; e<25; e++)
		{
if (xit == 1) {break;}
			slowrate = 1+tan((e+0.1)/20)*10;
			
			gravity = tan((e+0.1)/20)/2;

			for (f=0; f<n; f++)
			{
				particles[f][0] += particles[f][3]/slowrate;
				particles[f][1] += particles[f][4]/slowrate;
				particles[f][2] += particles[f][5]/slowrate;
				particles[f][2] -= gravity;

				setvoxel(particles[f][0],particles[f][1],particles[f][2]);


			}
if (xit == 1) {break;}
			delay_ms(1000);
			fill(0x00);
		}
if (xit == 1) {break;}
	}
}

void int_sidewaves(int iterations, int delay)
{
	//START_LUT // Macro
	unsigned char LUT[65];
	init_LUT(LUT);
	int i;
	int origin_x, origin_y, distance, height;
	int x_dist,x_dist2,y_dist;
	int x,y,x_vox;
	for (i=0;i<iterations;i++)
	{
if (xit == 1) {i=iterations;break;}
		// To provide some finer control over the integer calcs the x and y
		// parameters are scaled up by a factor of 15.  This is primarily to
		// keep the sum of their squares within the scale of an integer.
		// 120^2 + 120^2 = 28800
		// If we scaled by 16 we would overflow at the very extremes,
		// e.g 128^2+128^2=32768.  The largest int is 32767.
		//
		// Because origin_x/y is a sin/cos pair centred at 60, the actual
		// highest distance in this effect would be at:
		// x=8,y=8, origin_x=102, origin_y=102
		// = approximate sum of 17400.
		//
		// It is probably safer to work at a scale of 15 to allow simple changes
		// to the maths to be made without risking an overflow.
		origin_x=(totty_sin(LUT,i/2)+180)/3; // Approximately 0 to 120
		origin_y=(totty_cos(LUT,i/2)+180)/3;
		fill(0x00);
		for (x=8;x<120;x+=15)// 8 steps from 8 to 113
		{
			// Everything in here happens 8 times per cycle
			x_dist=abs(x-origin_x);
			x_dist2=x_dist*x_dist; // square of difference
			x_vox=x/15;//  Unscale x
			for (y=8;y<120;y+=15)
			{
				// Everything in here happens 64 times per cycle
				y_dist=abs(y-origin_y);
				if (x_dist||y_dist)//Either x OR y non-zero
				{
					// Calculate sum of squares of linear distances
					// We use a 1st order Newton approximation:
					// sqrt=(N/guess+guess)/2
					distance=(x_dist2+y_dist*y_dist);
					height=(x_dist+y_dist)/2; // Approximate quotient
					// We divide by 30.  1st approx would be /2
					// but we have a factor of 15 included in our scale calcs
					distance=(distance/height+height)/3; //1st approx at sqrt
				}
				else
					distance=0;//x and y = origin_x and origin_y
				height=(totty_sin(LUT,distance+i)+180)/52;
				setvoxel(x_vox,y/15,height);
if (xit == 1) {break;}
			}
if (xit == 1) {break;}
		}
if (xit == 1) {break;}
		delay_ms(delay);
	}
}

void effect_plane_flip(unsigned char LUT[],unsigned char start,unsigned char end,int delay)
{
	unsigned char p1,p2;// point across and down on flip
	unsigned char x,y,z;
	unsigned char i;// rotational position
	unsigned char i1;// linear position
	unsigned char dir=0;//0-2  0=sidetrap 1=door 2=trap
	unsigned char rev=0;//0 for forward 1 for reverse
	unsigned char inv=0;//bit 0=Y bit 1=Z
	// Sort out dir, rev and inv for each start/end combo.
	//  There are 24, but with some neat combinations of
	// tests we can simplify so that only a max of 3 tests
	// are required for each type!
	if (start<2)// 0 or 1.  buh
	{
		if (end<4)
		{
			dir=0;
			if (end==3) inv=0x01;
		}
		else
		{
			dir=2;
			if (end==5) inv=0x01;
		}
		if (start==1) inv|=0x02;
	} else if (start<4)//2 or 3. Buh
	{
		if (end<2)// going to 0 or 1
		{
			rev=1;
			dir=0;
			if (start==3) inv=0x01;
			if (end==1) inv|=0x02;
		}
		else // going to 4 or 5
		{
			dir=1;// door moves
			if(start+end==7)//3 to 4 or 2 to 5
			{
				if (start==3)
					inv=0x02;
				else
					inv=0x01;
			}
			else//2 to 4 or 3 to 5
			{
				if (start==3)
					inv=0x03;
			}
		}
	}
	else //start is 4 or 5
	{
		if (end<2)// 0 or 1
		{
			dir=2;
			rev=1;// reverse trapdoor.  Yeah!
			if (start+end==5)//4 to 1 or 5 to 0
			{
				if (start==4)//4 to 1
					inv=0x02;
				else
					inv=0x01;
			}
			else // 4 to 0 or 5 to 1
				if (start==5)
					inv=0x03;
		}
		else//end is 2 or 3
		{
			rev=1;// all reverse
			dir=1;// all door
			if (start+end==7)//4 to 3 or 5 to 2
			{
				if (start==4) // 4 to 3
					inv=0x02;
				else
					inv=0x01;
			}
			else
			{
				if (start==5)//5 to 3
					inv=0x03;
			}
		}
	}
	// Do the actual plane drawing
	for(i=1;i<9;i++) // changed from the original 0 to 7 to make sure it ends on a flat plane
	{
		if (rev)// Reverse movement goes cos-sin
		{
			p2=totty_sin(LUT,i*4);// angle 0-45 degrees
			p1=totty_cos(LUT,i*4);
		}
		else
		{
			p1=totty_sin(LUT,i*4);// angle 0-45 degrees
			p2=totty_cos(LUT,i*4);
		}
		fill(0x00);
		for (i1=0;i1<8;i1++)
		{
			z=p1*i1/168;
			if (inv&0x02) z=7-z;// invert in Z axis
			y=p2*i1/168;
			if (inv&0x01) y=7-y;// invert in Y axis
			for(x=0;x<8;x++)
			{
				if(!dir)//dir=0
				{
					setvoxel(x,y,z);
				}
				else if(dir==1)
				{
					setvoxel(y,z,x);
				}
				else//dir=2
				{
					setvoxel(y,x,z);
				}
if (xit == 1) {break;}
			}
if (xit == 1) {break;}
		}
if (xit == 1) {break;}
		delay_ms(delay);
	}
}

void effect_filip_filop(int iterations)
{
	LUT_START // Macro
	unsigned char now_plane=0;//start at top
	unsigned char next_plane;
	int delay=FF_DELAY;
	int i;//iteration counter
	for (i=iterations;i;i--)
	{
if (xit == 1) {i=iterations;break;}
		next_plane=rand()%6; //0-5
		// Check that not the same, and that:
		// 0/1 2/3 4/5 pairs do not exist.
		if ((next_plane&0x06)==(now_plane&0x06))
			next_plane=(next_plane+3)%6;
		effect_plane_flip(LUT,now_plane,next_plane,delay);
		now_plane=next_plane;
if (xit == 1) {break;}
	}
}

void effect_cubix(int iterations,unsigned char cubies)
{
	// cube array:
	// Stupid name to prevent confusion with cube[][]!
	// 0=pos
	// 1=dir (0 stopped 1,2 or 4 move in X, Y or Z)
	// 2=inc or dec in direction (2=inc, 0=dec)
	// 3=countdown to new movement
	// 4=x, 5=y, 6=z
	unsigned char qubes[cubies][7];
	int ii; // iteration counter
	unsigned char i,j,diridx,newdir;
	unsigned char runstate=2;
	//	Initialise qubes array
	for (i=0;i<cubies;i++)
	{
		qubes[i][0]=i;// position = i
		qubes[i][1]=0;// static
		qubes[i][3]=rand()&0x0f;// 0-15
		// Hack in the X,Y and Z positions
		qubes[i][4]=4*(i&0x01);
		qubes[i][5]=2*(i&0x02);
		qubes[i][6]=(i&0x04);
	}
	// Main loop
	ii=iterations;
	while((runstate) && (xit == 0))
	{
		fill(0x00);
		for (i=0;i<cubies;i++)
		{
			// Use a pointer to simplify array indexing
			// qube[0..7] = qubes[i][0..7]
			unsigned char *qube=&qubes[i][0];
			if (qube[1]) //moving
			{
				diridx=3+qube[1];//4,5 or 7
				if (diridx==7) diridx=6;
				qube[diridx]+=qube[2]-1;
				if ((qube[diridx]==0)||(qube[diridx]==4))
				{
					// XOR old pos and dir to get new pos.
					qube[0]=qube[0]^qube[1];
					qube[1]=0;// Stop moving!
					qube[3]=rand()&0x0f; // countdown to next move 0-15
					if(runstate==1)
						if (qube[0]<5)
							qube[3]*=1;// Make lower qubes move very slowly to finish was value 4
				}
			}
			else // not moving
			{
				if (qube[3])// counting down
					qube[3]--;
				else // ready to move
				{
					newdir=(1<<(rand()%3));//1,2 or 4
					diridx=qube[0]^newdir;
					for (j=0;j<cubies;j++)// check newdir is safe to move to
					{
						if ((diridx==qubes[j][0])||(diridx==(qubes[j][0]^qubes[j][1])))
						{
							newdir=0;
							qube[3]=5;
						}
					}

					if (newdir)
					{
						diridx=3+newdir;
						if (diridx==7) diridx=6;
						if (qube[diridx])// should be 4 or 0
							qube[2]=0; // dec if at 4
						else
						{
							qube[2]=2; // inc if at 0
							if(runstate==1)// Try to make qubes go home
								if ((diridx>4)&&(qube[0]<4))
									newdir=0;//Don't allow qubes on bottom row to move up or back
						}
					}
					qube[1]=newdir;
				}
			}
			//if (i&0x01)//odd number
				box_filled(qube[4],qube[5],qube[6],qube[4]+3,qube[5]+3,qube[6]+3);
			//else
			//	box_wireframe(qube[4],qube[5],qube[6],qube[4]+3,qube[5]+3,qube[6]+3);
		} // i loop
		delay_ms(800);
		if(runstate==2)// If normal running
		{
			if(!(--ii))// decrement iteration and check for zero
				runstate=1;// If zero go to homing
		}
		else//runstate at 1
		{
			diridx=0;
			for(j=0;j<cubies;j++)
				if (qubes[j][0]+1>cubies) diridx=1;// Any cube not at home
			if (!diridx)
				runstate=0;
if (xit == 1) {break;}
		}
if (xit == 1) {break;}
	} // Main loop
}

void int_ripples(int iterations, int delay)
{
// if (xit == 1) {break;}
	// 16 values for square root of a^2+b^2.  index a*4+b = 10*sqrt
	// This gives the distance to 3.5,3.5 from the point
	unsigned char sqrt_LUT[]={49,43,38,35,43,35,29,26,38,29,21,16,35,25,16,7};
	//LUT_START // Macro from new tottymath.  Commented and replaced with full code
	unsigned char LUT[65];
	init_LUT(LUT);
	int i;
	unsigned char x,y,height,distance;
	for (i=0;i<iterations*4;i+=4)
	{
if (xit == 1) {i = iterations;break;}
		fill(0x00);
		for (x=0;x<4;x++)
			for(y=0;y<4;y++)
			{
				// x+y*4 gives no. from 0-15 for sqrt_LUT
				distance=sqrt_LUT[x+y*4];// distance is 0-50 roughly
				// height is sin of distance + iteration*4
				//height=4+totty_sin(LUT,distance+i)/52;
				height=(196+totty_sin(LUT,distance+i))/49;
				// Use 4-way mirroring to save on calculations
				setvoxel(x,y,height);
				setvoxel(7-x,y,height);
				setvoxel(x,7-y,height);
				setvoxel(7-x,7-y,height);
			}
if (xit == 1) {break;}
		delay_ms(delay);
	}
}

void side_ripples(int iterations, int delay)
{
	// 16 values for square root of a^2+b^2.  index a*4+b = 10*sqrt
	// This gives the distance to 3.5,3.5 from the point
	unsigned char sqrt_LUT[]={49,43,38,35,43,35,29,26,38,29,21,16,35,25,16,7};
	//LUT_START // Macro from new tottymath.  Commented and replaced with full code
	unsigned char LUT[65];
	init_LUT(LUT);
	int i;
	unsigned char x,y,height,distance;
	for (i=0;i<iterations*4;i+=4)
	{
if (xit == 1) {i=iterations;break;}
		fill(0x00);
		for (x=0;x<4;x++)
			for(y=0;y<4;y++)
			{
				// x+y*4 gives no. from 0-15 for sqrt_LUT
				distance=sqrt_LUT[x+y*4];// distance is 0-50 roughly
				// height is sin of distance + iteration*4
				//height=4+totty_sin(LUT,distance+i)/52;
				height=(196+totty_sin(LUT,distance+i))/49;
				// Use 4-way mirroring to save on calculations
				setvoxel(x,height,y);
				setvoxel(7-x,height,y);
				setvoxel(x,height,7-y);
				setvoxel(7-x,height,7-y);
				setvoxel(x,7-height,y);
				setvoxel(7-x,7-height,y);
				setvoxel(x,7-height,7-y);
				setvoxel(7-x,7-height,7-y);
if (xit == 1) {break;}

			}
if (xit == 1) {break;}
		delay_ms(delay);
	}

}


void mirror_ripples(int iterations, int delay)
{

	// 16 values for square root of a^2+b^2.  index a*4+b = 10*sqrt
	// This gives the distance to 3.5,3.5 from the point
	unsigned char sqrt_LUT[]={49,43,38,35,43,35,29,26,38,29,21,16,35,25,16,7};
	//LUT_START // Macro from new tottymath.  Commented and replaced with full code
	unsigned char LUT[65];
	init_LUT(LUT);
	int i;
	unsigned char x,y,height,distance;
	for (i=0;i<iterations*4;i+=4)
	{
if (xit == 1) {i=iterations;break;}
		fill(0x00);
		for (x=0;x<4;x++)
			for(y=0;y<4;y++)
			{
				// x+y*4 gives no. from 0-15 for sqrt_LUT
				distance=sqrt_LUT[x+y*4];// distance is 0-50 roughly
				// height is sin of distance + iteration*4
				//height=4+totty_sin(LUT,distance+i)/52;
				height=(196+totty_sin(LUT,distance+i))/49;
				// Use 4-way mirroring to save on calculations
				setvoxel(x,y,height);
				setvoxel(7-x,y,height);
				setvoxel(x,7-y,height);
				setvoxel(7-x,7-y,height);
				setvoxel(x,y,7-height);
				setvoxel(7-x,y,7-height);
				setvoxel(x,7-y,7-height);
				setvoxel(7-x,7-y,7-height);
if (xit == 1) {break;}

			}
if (xit == 1) {break;}
		delay_ms(delay);
	}
}

void quad_ripples(int iterations, int delay)
{
	// 16 values for square root of a^2+b^2.  index a*4+b = 10*sqrt
	// This gives the distance to 3.5,3.5 from the point
	unsigned char sqrt_LUT[]={49,43,38,35,43,35,29,26,38,29,21,16,35,25,16,7};
	//LUT_START // Macro from new tottymath.  Commented and replaced with full code
	unsigned char LUT[65];
	init_LUT(LUT);
	int i;
	unsigned char x,y,height,distance;
	for (i=0;i<iterations*4;i+=4)
	{
if (xit == 1) {i=iterations;break;}
		fill(0x00);
		for (x=0;x<4;x++)
			for(y=0;y<4;y++)
			{
				// x+y*4 gives no. from 0-15 for sqrt_LUT
				distance=sqrt_LUT[x+y*4];// distance is 0-50 roughly
				// height is sin of distance + iteration*4
				//height=4+totty_sin(LUT,distance+i)/52;
				height=(196+totty_sin(LUT,distance+i))/49;
				// Use 4-way mirroring to save on calculations
				setvoxel(x,y,height);
				setvoxel(7-x,y,height);
				setvoxel(x,7-y,height);
				setvoxel(7-x,7-y,height);
				setvoxel(x,y,7-height);
				setvoxel(7-x,y,7-height);
				setvoxel(x,7-y,7-height);
				setvoxel(7-x,7-y,7-height);
				setvoxel(x,height,y);
				setvoxel(7-x,height,y);
				setvoxel(x,height,7-y);
				setvoxel(7-x,height,7-y);
				setvoxel(x,7-height,y);
				setvoxel(7-x,7-height,y);
				setvoxel(x,7-height,7-y);
				setvoxel(7-x,7-height,7-y);
if (xit == 1) {break;}


			}
		delay_ms(delay);
if (xit == 1) {break;}
	}
}



void effect_test (void)
{

	int x,y,i;

	for (i=0;i<1000;i++)
	{
		x = sin(i/8)*2+3.5;
		y = cos(i/8)*2+3.5;

		setvoxel(x,y,1);
		setvoxel(x,y,1);
		delay_ms(1000);
		fill(0x00);
	}

}


void effect_stringfly2(char * str)
{
	int x,y,i;
	unsigned char chr[5];
	
	while ((*str) && (xit == 0))
	{
		font_getchar(*str++, chr);
		
        // Put a character on the back of the cube
		for (x = 0; x < 5; x++)
		{
			for (y = 0; y < 8; y++)
			{
				if ((chr[x] & (0x80>>y)))
				{
					setvoxel(7,x+2,y);
					setvoxel(6,x+2,y);
				}
			}
		}
		
        // Shift the entire contents of the cube forward by 6 steps
        // before placing the next character
		for (i = 0; i<6; i++)
		{

			delay_ms(1000);
            shift(AXIS_X,-1);
		}
	}
    // Shift the last character out of the cube.
	for (i = 0; i<8; i++)
	{
		delay_ms(1000);
        shift(AXIS_X,-1);
	}
	
}

// Draw a plane on one axis and send it back and forth once.
void effect_planboing (int plane, int speed)
{
	int i;
	for (i=0;i<8;i++)
	{
		fill(0x00);
        setplane(plane, i);
		delay_ms(speed);
	}
	
	for (i=7;i>=0;i--)
	{
		fill(0x00);
        setplane(plane,i);
		delay_ms(speed);
	}
}

void effect_planboing2 (int plane, int speed)
{
	int i;
	for (i=0;i<8;i++)
	{
		// fill(0x00);
        setplane(plane, i);
		delay_ms(speed);
	}
	
	for (i=7;i>=0;i--)
	{
		fill(0x00);
        setplane(plane,i);
		delay_ms(speed);
	}
}

void effect_blinky2()
{
	int i,r;
	fill(0x00);
	
	for (r=0;r<2;r++)
	{
		i = 750;
		while (i>0)
		{
			fill(0x00);
			delay_ms(i);
			
			fill(0xff);
			delay_ms(100);
			
			i = i - (15+(1000/(i/10)));
		}
		
		delay_ms(1000);
		
		i = 750;
		while (i>0)
		{
			fill(0x00);
			delay_ms(751-i);
			
			fill(0xff);
			delay_ms(100);
			
			i = i - (15+(1000/(i/10)));
		}
	}

}

void effect_box_shrink_grow (int iterations, int rot, int flip, uint16_t delay)
{
	int x, i, xyz;
	for (x=0;x<iterations;x++)
	{
if (xit == 1) {x = iterations;break;}
		for (i=0;i<16;i++)
		{
if (xit == 1) {x = iterations;i=16;break;}
            xyz = 7-i; // This reverses counter i between 0 and 7.
            if (i > 7) 
                xyz = i-8; // at i > 7, i 8-15 becomes xyz 0-7.
            
            fill(0x00); delay_ms(1);
            cli(); // disable interrupts while the cube is being rotated
			box_wireframe(0,0,0,xyz,xyz,xyz);

            if (flip > 0) // upside-down
                mirror_z();

            if (rot == 1 || rot == 3)
                mirror_y();

            if (rot == 2 || rot == 3)
                mirror_x();
            
            sei(); // enable interrupts
			delay_ms(delay);
	        fill(0x00);
        }
    }
}

// Creates a wireframe box that shrinks or grows out from the center of the cube.
void effect_box_woopwoop (int delay, int grow)
{
	int i,ii;
	
	fill(0x00);
	for (i=0;i<4;i++)
	{
if (xit == 1) {i = 4;break;}
        ii = i;
        if (grow > 0)
            ii = 3-i;

		box_wireframe(4+ii,4+ii,4+ii,3-ii,3-ii,3-ii);
		delay_ms(delay);
		fill(0x00);
	}
}


// Send a voxel flying from one side of the cube to the other
// If its at the bottom, send it to the top..
void sendvoxel_z (unsigned char x, unsigned char y, unsigned char z, int delay)
{
	int i, ii;
	for (i=0; i<8; i++)
	{
		if (z == 7)
		{
			ii = 7-i;
			clrvoxel(x,y,ii+1);
		} else
		{
			ii = i;
			clrvoxel(x,y,ii-1);
		}
		setvoxel(x,y,ii);
		delay_ms(delay);
	}
}

// Send all the voxels from one side of the cube to the other
// Start at z and send to the opposite side.
// Sends in random order.
void sendplane_rand_z (unsigned char z, int delay, int wait)
{
	unsigned char loop = 16;
	unsigned char x, y;

	fill(0x00);

	setplane_z(z);
	
	// Send voxels at random untill all 16 have crossed the cube.
	while(loop)
	{
		x = rand()%4;
		y = rand()%4;
		if (getvoxel(x,y,z))
		{
			// Send the voxel flying
			sendvoxel_z(x,y,z,delay);
			delay_ms(wait);
			loop--; // one down, loop-- to go. when this hits 0, the loop exits. 
		}
	}
}

// For each coordinate along X and Y, a voxel is set either at level 0 or at level 7
// for n iterations, a random voxel is sent to the opposite side of where it was.
void sendvoxels_rand_z (int iterations, int delay, int wait)
{
	unsigned char x, y, last_x = 0, last_y = 0, i;

	fill(0x00);

	// Loop through all the X and Y coordinates
	for (x=0;x<8;x++)
	{
		for (y=0;y<8;y++)
		{
			// Then set a voxel either at the top or at the bottom
            // rand()%2 returns either 0 or 1. multiplying by 7 gives either 0 or 7.
            setvoxel(x,y,((rand()%2)*7));
		}
	}

	for (i=0;i<iterations;i++)
	{
		// Pick a random x,y position
		x = rand()%8;
		y = rand()%8;
		// but not the sameone twice in a row
		if (y != last_y && x != last_x)
		{
			// If the voxel at this x,y is at the bottom
			if (getvoxel(x,y,0))
			{
				// send it to the top
				sendvoxel_z(x,y,0,delay);
			} else
			{
				// if its at the top, send it to the bottom
				sendvoxel_z(x,y,7,delay);
			}
			delay_ms(wait);
			
			// Remember the last move
			last_y = y;
			last_x = x;
		}
	}

}


// Big ugly function :p but it looks pretty
void boingboing(uint16_t iterations, int delay, unsigned char mode, unsigned char drawmode)
{
	fill(0x00);		// Blank the cube

	int x, y, z;		// Current coordinates for the point
	int dx, dy, dz;	// Direction of movement
	int lol, i;		// lol?
	unsigned char crash_x, crash_y, crash_z;

	y = rand()%8;
	x = rand()%8;
	z = rand()%8;

	// Coordinate array for the snake.
	int snake[8][3];
	for (i=0;i<8;i++)
	{
		snake[i][0] = x;
		snake[i][1] = y;
		snake[i][2] = z;
	}
	
	
	dx = 1;
	dy = 1;
	dz = 1;
	
	while(iterations)
	{
		crash_x = 0;
		crash_y = 0;
		crash_z = 0;
	

		// Let's mix things up a little:
		if (rand()%3 == 0)
		{
			// Pick a random axis, and set the speed to a random number.
			lol = rand()%3;
			if (lol == 0)
				dx = rand()%3 - 1;
			
			if (lol == 1)
				dy = rand()%3 - 1;
				
			if (lol == 2)
				dz = rand()%3 - 1;
		}

	    // The point has reached 0 on the x-axis and is trying to go to -1
        // aka a crash
		if (dx == -1 && x == 0)
		{
			crash_x = 0x01;
			if (rand()%3 == 1)
			{
				dx = 1;
			} else
			{
				dx = 0;
			}
		}
		
        // y axis 0 crash
		if (dy == -1 && y == 0)
		{
			crash_y = 0x01;
			if (rand()%3 == 1)
			{
				dy = 1;
			} else
			{
				dy = 0;
			}
		}
		
        // z axis 0 crash
		if (dz == -1 && z == 0)
		{
			crash_z = 0x01;
			if (rand()%3 == 1)
			{
				dz = 1;
			} else
			{
				dz = 0;
			}
		}
	    
        // x axis 7 crash
		if (dx == 1 && x == 7)
		{
			crash_x = 0x01;
			if (rand()%3 == 1)
			{
				dx = -1;
			} else
			{
				dx = 0;
			}
		}
		
        // y axis 7 crash
		if (dy == 1 && y == 7)
		{
			crash_y = 0x01;
			if (rand()%3 == 1)
			{
				dy = -1;
			} else
			{
				dy = 0;
			}
		}
		
        // z azis 7 crash
		if (dz == 1 && z == 7)
		{
			crash_z = 0x01;
			if (rand()%3 == 1)
			{
				dz = -1;
			} else
			{
				dz = 0;
			}
		}
		
		// mode bit 0 sets crash action enable
		if (mode | 0x01)
		{
			if (crash_x)
			{
				if (dy == 0)
				{
					if (y == 7)
					{
						dy = -1;
					} else if (y == 0)
					{
						dy = +1;
					} else
					{
						if (rand()%2 == 0)
						{
							dy = -1;
						} else
						{
							dy = 1;
						}
					}
				}
				if (dz == 0)
				{
					if (z == 7)
					{
						dz = -1;
					} else if (z == 0)
					{
						dz = 1;
					} else
					{
						if (rand()%2 == 0)
						{
							dz = -1;
						} else
						{
							dz = 1;
						}
					}	
				}
			}
			
			if (crash_y)
			{
				if (dx == 0)
				{
					if (x == 7)
					{
						dx = -1;
					} else if (x == 0)
					{
						dx = 1;
					} else
					{
						if (rand()%2 == 0)
						{
							dx = -1;
						} else
						{
							dx = 1;
						}
					}
				}
				if (dz == 0)
				{
					if (z == 3)
					{
						dz = -1;
					} else if (z == 0)
					{
						dz = 1;
					} else
					{
						if (rand()%2 == 0)
						{
							dz = -1;
						} else
						{
							dz = 1;
						}
					}	
				}
			}
			
			if (crash_z)
			{
				if (dy == 0)
				{
					if (y == 7)
					{
						dy = -1;
					} else if (y == 0)
					{
						dy = 1;
					} else
					{
						if (rand()%2 == 0)
						{
							dy = -1;
						} else
						{
							dy = 1;
						}
					}	
				}
				if (dx == 0)
				{
					if (x == 7)
					{
						dx = -1;
					} else if (x == 0)
					{
						dx = 1;
					} else
					{
						if (rand()%2 == 0)
						{
							dx = -1;
						} else
						{
							dx = 1;
						}
					}	
				}
			}
		}
		
		// mode bit 1 sets corner avoid enable
		if (mode | 0x02)
		{
			if (	// We are in one of 8 corner positions
				(x == 0 && y == 0 && z == 0) ||
				(x == 0 && y == 0 && z == 7) ||
				(x == 0 && y == 7 && z == 0) ||
				(x == 0 && y == 7 && z == 7) ||
				(x == 7 && y == 0 && z == 0) ||
				(x == 7 && y == 0 && z == 7) ||
				(x == 7 && y == 7 && z == 0) ||
				(x == 7 && y == 7 && z == 7)
			)
			{
				// At this point, the voxel would bounce
				// back and forth between this corner,
				// and the exact opposite corner
				// We don't want that!
			
				// So we alter the trajectory a bit,
				// to avoid corner stickyness
				lol = rand()%3;
				if (lol == 0)
					dx = 0;
				
				if (lol == 1)
					dy = 0;
					
				if (lol == 2)
					dz = 0;
			}
		}

        // one last sanity check
        if (x == 0 && dx == -1)
            dx = 1;
	
        if (y == 0 && dy == -1)
            dy = 1;
	
        if (z == 0 && dz == -1)
            dz = 1;
	
        if (x == 7 && dx == 1)
            dx = -1;
	
        if (y == 7 && dy == 1)
            dy = -1;
	
        if (z == 7 && dz == 1)
            dz = -1;
	
	
		// Finally, move the voxel.
		x = x + dx;
		y = y + dy;
		z = z + dz;
		
		if (drawmode == 0x01) // show one voxel at time
		{
			setvoxel(x,y,z);
			delay_ms(delay);
			clrvoxel(x,y,z);	
		} else if (drawmode == 0x02) // flip the voxel in question
		{
			flpvoxel(x,y,z);
			delay_ms(delay);
		} if (drawmode == 0x03) // draw a snake
		{
			for (i=7;i>=0;i--)
			{
				snake[i][0] = snake[i-1][0];
				snake[i][1] = snake[i-1][1];
				snake[i][2] = snake[i-1][2];
			}
			snake[0][0] = x;
			snake[0][1] = y;
			snake[0][2] = z;
				
			for (i=0;i<8;i++)
			{
				setvoxel(snake[i][0],snake[i][1],snake[i][2]);
			}
			delay_ms(delay);
			for (i=0;i<8;i++)
			{
				clrvoxel(snake[i][0],snake[i][1],snake[i][2]);
			}
		}
		
	
		iterations--;
	}
}

// Set or clear exactly 512 voxels in a random order.
void effect_random_filler (int delay, int state)
{
	int x,y,z;
	int loop = 0;
	
	
	if (state == 1)
	{
		fill(0x00);
	} else
	{
		fill(0xff);
	}
	
	while (loop<511)
	{
		x = rand()%8;
		y = rand()%8;
		z = rand()%8;

		if ((state == 0 && getvoxel(x,y,z) == 0x01) || (state == 1 && getvoxel(x,y,z) == 0x00))
		{
			altervoxel(x,y,z,state);
			delay_ms(delay);
			loop++;
		}	
	}
}


void effect_rain (int iterations)
{
	int i, ii;
	int rnd_x;
	int rnd_y;
	int rnd_num;
	
	for (ii=0;ii<iterations;ii++)
	{
if (xit == 1) {ii = iterations;break;}
		rnd_num = rand()%4;
		
		for (i=0; i < rnd_num;i++)
		{
			rnd_x = rand()%8;
			rnd_y = rand()%8;
			setvoxel(rnd_x,rnd_y,7);
if (xit == 1) {ii = iterations;break;}
		}
		
		delay_ms(1000);
		shift(AXIS_Z,-1);
if (xit == 1) {ii = iterations;break;}
	}
}

void effect_z_updown (int iterations, int delay)
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
		delay_ms(delay);
	}
	
	for (i=0;i<iterations;i++)
	{
if (xit == 1) {i = iterations;break;}
		for (move=0;move<8;move++)
		{
			effect_z_updown_move(positions, destinations, AXIS_Z);
			delay_ms(delay);
		}

		delay_ms(delay*4);


		for (y=0;y<32;y++)
		{
				destinations[rand()%64] = rand()%8;
if (xit == 1) {i = iterations; y=32;;break;}
		}
		
	}

}

void effect_z_updown_move (unsigned char positions[64], unsigned char destinations[64], char axis)
{
	int px;
	for (px=0; px<64; px++)
	{
if (xit == 1) {px=64;break;}
		if (positions[px]<destinations[px])
		{
			positions[px]++;
		}
		if (positions[px]>destinations[px])
		{
			positions[px]--;
		}
	}
		
	draw_positions_axis (AXIS_Z, positions,0);
}

void effect_axis_updown_randsuspend (char axis, int delay, int sleep, int invert)
{
	unsigned char positions[64];
	unsigned char destinations[64];

	int i,px;
	
    // Set 64 random positions
	for (i=0; i<64; i++)
	{
		positions[i] = 0; // Set all starting positions to 0
		destinations[i] = rand()%8;
	}

    // Loop 8 times to allow destination 7 to reach all the way
	for (i=0; i<8; i++)
	{
        // For every iteration, move all position one step closer to their destination
		for (px=0; px<64; px++)
		{
if (xit == 1) {i = 8; px=64;break;}
			if (positions[px]<destinations[px])
			{
				positions[px]++;
			}
		}
        // Draw the positions and take a nap
		draw_positions_axis (axis, positions,invert);
		delay_ms(delay);
	}
	
    // Set all destinations to 7 (opposite from the side they started out)
	for (i=0; i<64; i++)
	{
		destinations[i] = 7;
if (xit == 1) {i = 64;break;}
	}
	
    // Suspend the positions in mid-air for a while
	delay_ms(sleep);
	
    // Then do the same thing one more time
	for (i=0; i<8; i++)
	{
		for (px=0; px<64; px++)
		{
if (xit == 1) {i = 8; px=64;break;}
			if (positions[px]<destinations[px])
			{
				positions[px]++;
			}
			if (positions[px]>destinations[px])
			{
				positions[px]--;
			}
		}
		draw_positions_axis (axis, positions,invert);
		delay_ms(delay);
	}
}

void draw_positions_axis (char axis, unsigned char positions[64], int invert)
{
	int x, y, p;
	
	fill(0x00);
	
	for (x=0; x<8; x++)
	{
		for (y=0; y<8; y++)
		{
			if (invert)
			{
				p = (7-positions[(x*8)+y]);
			} else
			{
				p = positions[(x*8)+y];
			}
		
			if (axis == AXIS_Z)
				setvoxel(x,y,p);
				
			if (axis == AXIS_Y)
				setvoxel(x,p,y);
				
			if (axis == AXIS_X)
				setvoxel(p,y,x);
		}
	}
	
}


void effect_boxside_randsend_parallel (char axis, int origin, int delay, int mode)
{
	int i;
	int done;
	unsigned char cubepos[64];
	unsigned char pos[64];
	int notdone = 1;
	int notdone2 = 1;
	int sent = 0;
	
	for (i=0;i<64;i++)
	{
		pos[i] = 0;
	}
	
	while (notdone)
	{
		if (mode == 1)
		{
			notdone2 = 1;
			while (notdone2 && sent<64)
			{
				i = rand()%64;
				if (pos[i] == 0)
				{
					sent++;
					pos[i] += 1;
					notdone2 = 0;
				}
			}
		} else if (mode == 2)
		{
			if (sent<64)
			{
				pos[sent] += 1;
				sent++;
			}
		}
		
		done = 0;
		for (i=0;i<64;i++)
		{
			if (pos[i] > 0 && pos[i] <7)
			{
				pos[i] += 1;
			}
				
			if (pos[i] == 7)
				done++;
		}
		
		if (done == 64)
			notdone = 0;
		
		for (i=0;i<64;i++)
		{
			if (origin == 0)
			{
				cubepos[i] = pos[i];
			} else
			{
				cubepos[i] = (7-pos[i]);
			}
		}
		
		
		delay_ms(delay);
		draw_positions_axis(axis,cubepos,0);
		LED_PORT ^= LED_RED;
	}
	
}




// Light all leds layer by layer,
// then unset layer by layer
void effect_loadbar(int delay)
{
	fill(0x00);
	
	int z,y;
	
	for (z=0;z<8;z++)
	{
		for (y=0;y<8;y++)
			cube[z][y] = 0xff;
			
		delay_ms(delay);
	}
	
	delay_ms(delay*3);
	
	for (z=0;z<8;z++)
	{
		for (y=0;y<8;y++)
			cube[z][y] = 0x00;
			
		delay_ms(delay);
	}
}


// Set n number of voxels at random positions
void effect_random_sparkle_flash (int iterations, int voxels, int delay)
{
	int i;
	int v;
	for (i = 0; i < iterations; i++)
	{
		for (v=0;v<=voxels;v++)
			setvoxel(rand()%8,rand()%8,rand()%8);
			
		delay_ms(delay);
		fill(0x00);
	}
}

// blink 1 random voxel, blink 2 random voxels..... blink 20 random voxels
// and back to 1 again.
void effect_random_sparkle (void)
{
	int i;
	
	for (i=1;i<20;i++)
	{
		effect_random_sparkle_flash(5,i,200);
	}
	
	for (i=20;i>=1;i--)
	{
		effect_random_sparkle_flash(5,i,200);
	}
	
}

int effect_telcstairs_do(int x, int val, int delay)
{
	int y,z;

	for(y = 0, z = x; y <= z; y++, x--)
	{
		if(x < CUBE_SIZE && y < CUBE_SIZE)
		{
			cube[x][y] = val;
		}
	}
	delay_ms(delay);
	return z;
}

void effect_telcstairs (int invert, int delay, int val)
{
	int x;

	if(invert)
	{
		for(x = CUBE_SIZE*2; x >= 0; x--)
		{
			x = effect_telcstairs_do(x,val,delay);
		}
	}
	else
	{
		for(x = 0; x < CUBE_SIZE*2; x++)
		{
			x = effect_telcstairs_do(x,val,delay);
		}
	}
}

void effect_wormsqueeze (int size, int axis, int direction, int iterations, int delay)
{
	int x, y, i,j,k, dx, dy;
	int cube_size;
	int origin = 0;
	
	if (direction == -1)
		origin = 7;
	
	cube_size = 8-(size-1);
	
	x = rand()%cube_size;
	y = rand()%cube_size;
	
	for (i=0; i<iterations; i++)
	{
		dx = ((rand()%3)-1);
		dy = ((rand()%3)-1);
	
		if ((x+dx) > 0 && (x+dx) < cube_size)
			x += dx;
			
		if ((y+dy) > 0 && (y+dy) < cube_size)
			y += dy;
	
		shift(axis, direction);
		

		for (j=0; j<size;j++)
		{
			for (k=0; k<size;k++)
			{
if (xit == 1) {i=iterations;j=size;k=size;break;}
				if (axis == AXIS_Z)
					setvoxel(x+j,y+k,origin);
					
				if (axis == AXIS_Y)
					setvoxel(x+j,origin,y+k);
					
				if (axis == AXIS_X)
					setvoxel(origin,y+j,x+k);
			}
		}
		
		delay_ms(delay);
	}
}

void effect_smileyspin (int count, int delay, char bitmap)
{
	unsigned char dybde[] = {0,1,2,3,4,5,6,7,1,1,2,3,4,5,6,6,2,2,3,3,4,4,5,5,3,3,3,3,4,4,4,4};
	int d = 0;
	int flip = 0;
	int x, y, off;
	for(int i = 0; i<count; i++)
	{
		flip = 0;
		d = 0;
		off = 0;
		// front:
		for (int s=0;s<7;s++){
			if(!flip){
				off++;
				if (off == 4){
					flip = 1;
					off = 0;
				}
			} else {
				off++;
			}
		        for (x=0; x<8; x++)
        		{
				d = 0;
                		for (y=0; y<8; y++)
	                	{
if (xit == 1) {i=count;s=7;x=8;break;}
					if (font_getbitmappixel ( bitmap, 7-x, y)){
						if (!flip)
							setvoxel(y,dybde[8 * off + d++],x);
						else
							setvoxel(y,dybde[31 - 8 * off - d++],x);
					} else {
						d++;
					}
				}
			}
if (xit == 1) {i=count;s=7;x=8;break;}
			delay_ms(delay);
			fill(0x00);
		}

		// side:
		off = 0;
		flip = 0;
		d = 0;
		for (int s=0;s<7;s++){
			if(!flip){
				off++;
				if (off == 4){
					flip = 1;
					off = 0;
				}
			} else {
				off++;
			}
		        for (x=0; x<8; x++)
        		{
				d = 0;
                		for (y=0; y<8; y++)
	                	{
if (xit == 1) {i=count;s=7;x=8;y=8;break;}
					if (font_getbitmappixel ( bitmap, 7-x, y)){
						if (!flip)
							setvoxel(dybde[8 * off + d++], 7 - y,x);
						else
							setvoxel(dybde[31 - 8 * off - d++],7 - y,x);
					} else {
						d++;
					}
				}
			}
			delay_ms(delay);
			fill(0x00);
		}


		flip = 0;
		d = 0;
		off = 0;
		// back:
		for (int s=0;s<7;s++){
			if(!flip){
				off++;
				if (off == 4){
					flip = 1;
					off = 0;
				}
			} else {
				off++;
			}
		        for (x=0; x<8; x++)
        		{
				d = 0;
                		for (y=0; y<8; y++)
	                	{
if (xit == 1) {i=count;s=7;x=8;y=8;break;}
					if (font_getbitmappixel ( bitmap, 7-x, 7-y)){
						if (!flip)
							setvoxel(y,dybde[8 * off + d++],x);
						else
							setvoxel(y,dybde[31 - 8 * off - d++],x);
					} else {
						d++;
					}
				}
			}
			delay_ms(delay);
			fill(0x00);
		}

		// other side:
		off = 0;
		flip = 0;
		d = 0;
		for (int s=0;s<7;s++){
			if(!flip){
				off++;
				if (off == 4){
					flip = 1;
					off = 0;
				}
			} else {
				off++;
			}
		        for (x=0; x<8; x++)
        		{
				d = 0;
                		for (y=0; y<8; y++)
	                	{
if (xit == 1) {i=count;s=7;x=8;y=8;break;}
					if (font_getbitmappixel ( bitmap, 7-x, 7-y)){
						if (!flip)
							setvoxel(dybde[8 * off + d++], 7 - y,x);
						else
							setvoxel(dybde[31 - 8 * off - d++],7 - y,x);
					} else {
						d++;
					}
				}
			}
			delay_ms(delay);
			fill(0x00);
		}

	}
}


void effect_pathmove (unsigned char *path, int length)
{
	int i,z;
	unsigned char state;
	
	for (i=(length-1);i>=1;i--)
	{
if (xit == 1) {i = 0;break;}
		for (z=0;z<8;z++)
		{
		if (xit == 1) {i = 0;break;}
			state = getvoxel(((path[(i-1)]>>4) & 0x0f), (path[(i-1)] & 0x0f), z);
			altervoxel(((path[i]>>4) & 0x0f), (path[i] & 0x0f), z, state);
		}
if (xit == 1) {i = 0;break;}
	}
	for (i=0;i<8;i++){
		clrvoxel(((path[0]>>4) & 0x0f), (path[0] & 0x0f),i);
 if (xit == 1) {i = 0;break;}
}
}
void effect_rand_patharound (int iterations, int delay)
{
	int z, dz, i;
	z = 4;
	unsigned char path[28];
	
	font_getpath(0,path,28);
	
	for (i = 0; i < iterations; i++)
	{
if (xit == 1) {i = iterations;break;}
		dz = ((rand()%3)-1);
		z += dz;
		
		if (z>7)
			z = 7;
			
		if (z<0)
			z = 0;
		
		effect_pathmove(path, 28);
		setvoxel(0,7,z);
		delay_ms(delay);
	
	}
}

void effect_pathspiral (int iterations, int delay)
{
	int z, i;
	z = 4;
	unsigned char path[16];
	
	font_getpath(1,path,16);
	
	for (i = 0; i < iterations; i++)
	{
		setvoxel(4,0,i%8);
		delay_ms(delay);
		effect_pathmove(path, 28);
		
	}
}

void effect_path_text (int delay, char *str)
{
	int z, i,ii;
	z = 4;
	unsigned char path[28];
	font_getpath(0,path,28);
	
	unsigned char chr[5];
	unsigned char stripe;
	
	while (*str && !xit)
	{
		//charfly(*str++, direction, axis, mode, delay);
		
		
		font_getchar(*str++, chr);
		
		for (ii=0;ii<5;ii++)
		{
			//stripe = pgm_read_byte(&font[(chr*5)+ii]);
			stripe = chr[ii];
			
			for (z=0;z<8;z++)
			{
				if ((stripe>>(7-z)) & 0x01)
				{
					setvoxel(0,7,z);
				} else
				{
					clrvoxel(0,7,z);
				}
				
			}
			effect_pathmove(path, 28);
			delay_ms(delay);
		}
	
		effect_pathmove(path, 28);
		delay_ms(delay);
	}
	for (i=0;i<28;i++)
	{
		effect_pathmove(path, 28);
		delay_ms(delay);
	}
}

void effect_path_bitmap (int delay, char bitmap, int iterations)
{
	int z, i, ii;
	z = 4;
	unsigned char path[28];
	font_getpath(0,path,28);
	
	for (i=0; i < iterations; i++)
	{	
if (xit == 1) {i = iterations;ii = 8;z = 8;break;}

		for (ii=0;ii<8;ii++)
		{
if (xit == 1) {i = iterations;ii = 8;z = 8;break;}	
			for (z=0;z<8;z++)
			{
if (xit == 1) {i = iterations;ii = 8;z = 8;break;}
				if (font_getbitmappixel(bitmap,(7-z),ii))
				{
					setvoxel(0,7,z);
				} else
				{
					clrvoxel(0,7,z);
				}
if (xit == 1) {i = iterations;ii = 8;z = 8;break;}

			}
			delay_ms(delay);
if (xit == 1) {i = iterations;ii = 8;z = 8;break;}
			effect_pathmove(path, 28);
if (xit == 1) {i = iterations;break;}
		}
	
		for (ii=0;ii<20;ii++)
		{
			delay_ms(delay);
if (xit == 1) {i = iterations;ii = 8;z = 8;break;}
			effect_pathmove(path, 28);
		}
	}
	for (ii=0;ii<10;ii++)
	{
if (xit == 1) {ii = 10;break;}

		delay_ms(delay);
		effect_pathmove(path, 28);
	}

}


