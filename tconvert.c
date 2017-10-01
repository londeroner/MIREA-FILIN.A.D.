#include "stdio.h"
#include "stdlib.h"
#include "string.h"

void FromC(int temperature);
void FromF(int temperature);
void FromK(int temperature);

int main(int argc, char *argv[])
{
	if (argc == 3) 
	{
		if (!(strcmp(argv[2], "C")) || !(strcmp(argv[2], "c")))	
		{
			printf("%s C: \n", argv[1]);
			FromC(atoi(argv[1]));
		}
		if (!(strcmp(argv[2], "F")) || !(strcmp(argv[2], "f")))	
		{
			printf("%s F: \n", argv[1]);
			FromF(atoi(argv[1]));
		} 
		if (!(strcmp(argv[2], "K")) || !(strcmp(argv[2], "k")))	
		{
			printf("%s K: \n", argv[1]);
			FromK(atoi(argv[1]));
		}
	}
	else 
	{
		printf("%s C: \n", argv[1]);
		FromC(atoi(argv[1]));
		printf("%s F: \n", argv[1]);
		FromF(atoi(argv[1]));
		printf("%s K: \n", argv[1]);
		FromK(atoi(argv[1]));
	}
}

void FromC(int temperature)
{
	if (temperature < -273.15f) printf("Incorrect temperature\n\n");
	else
	{
		printf("F: %.2f\n", (temperature*1.8)+32);
		printf("K: %.2f\n\n", temperature+273.15);
	}
}

void FromF(int temperature)
{
	if (temperature < -459) printf("Incorrect temperature\n\n");
	else
	{
		printf("C: %.2f\n", (temperature-32)/1.8);
		printf("K: %.2f\n\n", ((temperature-32)/1.8)+273.15);
	}
}

void FromK(int temperature)
{
	if (temperature < 0) printf("Incorrect temperature\n\n");
	else
	{
		printf("C: %.2f\n", temperature-273.15);
		printf("F: %.2f\n\n", ((temperature-273.15)*1.8)+32);
	}
}
