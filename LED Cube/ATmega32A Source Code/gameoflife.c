#include <avr/io.h>
#include "gameoflife.h"
#include "cube.h"
#include "draw.h"

// Game of Life for the 4x4x4 and 8x8x8 led cube

#define GOL_CREATE_MIN 4
#define GOL_CREATE_MAX 4

// Added 1 to each of these.  Current cell is always alive
// when checking them!  Originally 3 and 5

#define GOL_TERMINATE_LONELY 4
#define GOL_TERMINATE_CROWDED 6

#define GOL_X 8
#define GOL_Y 8
#define GOL_Z 8

#define GOL_WRAP 0x01



void gol_play (int iterations, uint16_t delay)
{
	int i;
	
	for (i = 0; i < iterations; i++)
	{
		LED_PORT ^= LED_GREEN;
	
		gol_nextgen();
		if (!(i & 7))// Check every 8th cycle for end of life.
		{
			if (gol_count_changes() == 0)
				return;
		}
		tmp2cube();
		
		delay_ms(delay);
		
		//led_red(1);
	}
}

void gol_nextgen (void)
{
	signed char x,y,z;
	unsigned char neigh;
	unsigned char xbits,nxbits;
	signed char ix, iy, iz; // offset 1 in each direction in each dimension
	signed char nx, ny, nz; // neighbours address.
	tmpfill(0x00);
	
	for (x = 0; x < 8; x++)
	{
		xbits=(1<<x);
		for (y = 0; y < 8; y++)
		{
			for (z = 0; z < 8; z++)
			{
				neigh = 0;
				// unwrapped call from gol_count_neighbours
				for (ix = -1; ix < 2; ix++)
				{
					nx = (x+ix);
					if (!(nx & 0x08)) // Either 0x08 or 0xFF will have 4th bit set.
					{
						nxbits=(1 << nx);
						for (iy = -1; iy < 2; iy++)
						{
							ny = (y+iy);
							if (!(ny & 0x08))
							{
								for (iz = -1; iz < 2; iz++)
								{
									nz = (z+iz);
									if (!(nz & 0x08))
										if (cube[nz][ny] & nxbits)
											neigh++;
								}
							}
						}
					}
				}
				// Current voxel is alive.
				if (cube[z][y] & (1 << x))
				{
					if (neigh > GOL_TERMINATE_LONELY && neigh < GOL_TERMINATE_CROWDED)
						fb[z][y] |= xbits;
				// Current voxel is dead.
				}
				else
				{
					if (neigh >= GOL_CREATE_MIN && neigh <= GOL_CREATE_MAX)
						fb[z][y] |= xbits;
				}
			}
		}
	}
}

unsigned char gol_count_changes (void)
{
	unsigned char x,y;
	
	for (x = 0; x < GOL_X; x++)
	{
		for (y = 0; y < GOL_Y; y++)
		{
			if (fb[x][y] != cube[x][y])
				return 1;
		}
	}
	return 0;
}

