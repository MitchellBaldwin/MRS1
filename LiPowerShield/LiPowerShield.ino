/*
 Name:		LiPowerShield.ino
 Created:	3/9/2016 10:54:49 AM
 Author:	Mitchell
*/

/* LiPower Shield Example Code
by: Jim Lindblom
SparkFun Electronics
date: 1/3/12

license: Creative Commons Attribution-ShareAlike 3.0 (CC BY-SA 3.0)
Do whatever you'd like with this code, use it for any purpose.
Please attribute and keep this license. And let me know if you
make any major, awesome changes!

This is example code for the MAX17043G chip on the LiPower Shield.
The MAX17043G+U is a compact, low-cost 1S LiPo fuel gauge.
The Arduino talks with the MAX17043 over an I2C (two-wire) interface,
so we'll use the Wire.h library to talk with it.

It's a silly example. It reads the battery voltage, and its percentage
full and prints it out over serial. You probably wouldn't care about
the battery voltage if you had the Arduino connected via USB. But this
code does show you how to configure the MAX17043G, and how to read and
manipulate the voltage values.

This file was written to be compatible with Arduino 1.0. If you
have Arduino 0023 or earlier, you'll need to change the Wire.read()'s
to Wire.receive() and the Wire.write()'s to Wire.send();. And maybe rename
the .ino to .pde.
*/
#include <Wire.h>

#define MAX17043_ADDRESS 0x36  // R/W =~ 0x6D/0x6C

// Pin definitions
int alertPin = 2;  // This is the alert interrupt pin, connected to pin 2 on the LiPower Shield

// Global Variables
float batVoltage;
float batPercentage;
int alertStatus;

void setup()
{
	pinMode(alertPin, INPUT);
	digitalWrite(alertPin, HIGH);

	Serial.begin(9600);  // Start hardware serial
	Serial.println("Hello World");

	Wire.begin();  // Start I2C
	delay(100);
	configMAX17043(32);  // Configure the MAX17043's alert percentage
	qsMAX17043();  // restart fuel-gauge calculations
}

void loop()
{
	batPercentage = percentMAX17043();
	batVoltage = (float) vcellMAX17043() * 1 / 800;  // vcell reports battery in 1.25mV increments
	alertStatus = digitalRead(alertPin);

	Serial.print(batPercentage, 2);  // Print the battery percentage
	Serial.println(" %");
	Serial.print(batVoltage, 2);  // print battery voltage
	Serial.println(" V");
	Serial.print("Alert Status = ");
	Serial.println(alertStatus, DEC);
	Serial.println();
	delay(1000);
}

/*
vcellMAX17043() returns a 12-bit ADC reading of the battery voltage,
as reported by the MAX17043's VCELL register.
This does not return a voltage value. To convert this to a voltage,
multiply by 5 and divide by 4096.
*/
unsigned int vcellMAX17043()
{
	unsigned int vcell;

	vcell = i2cRead16(0x02);
	vcell = vcell >> 4;  // last 4 bits of vcell are nothing

	return vcell;
}

/*
percentMAX17043() returns a float value of the battery percentage
reported from the SOC register of the MAX17043.
*/
float percentMAX17043()
{
	unsigned int soc;
	float percent;

	soc = i2cRead16(0x04);  // Read SOC register of MAX17043
	percent = (byte) (soc >> 8);  // High byte of SOC is percentage
	percent += ((float) ((byte) soc)) / 256;  // Low byte is 1/256%

	return percent;
}

/*
configMAX17043(byte percent) configures the config register of
the MAX170143, specifically the alert threshold therein. Pass a
value between 1 and 32 to set the alert threshold to a value between
1 and 32%. Any other values will set the threshold to 32%.
*/
void configMAX17043(byte percent)
{
	if ((percent >= 32) || (percent == 0))  // Anything 32 or greater will set to 32%
		i2cWrite16(0x9700, 0x0C);
	else
	{
		byte percentBits = 32 - percent;
		i2cWrite16((0x9700 | percentBits), 0x0C);
	}
}

/*
qsMAX17043() issues a quick-start command to the MAX17043.
A quick start allows the MAX17043 to restart fuel-gauge calculations
in the same manner as initial power-up of the IC. If an application's
power-up sequence is very noisy, such that excess error is introduced
into the IC's first guess of SOC, the Arduino can issue a quick-start
to reduce the error.
*/
void qsMAX17043()
{
	i2cWrite16(0x4000, 0x06);  // Write a 0x4000 to the MODE register
}

/*
i2cRead16(unsigned char address) reads a 16-bit value beginning
at the 8-bit address, and continuing to the next address. A 16-bit
value is returned.
*/
unsigned int i2cRead16(unsigned char address)
{
	int data = 0;

	Wire.beginTransmission(MAX17043_ADDRESS);
	Wire.write(address);
	Wire.endTransmission();

	Wire.requestFrom(MAX17043_ADDRESS, 2);
	while (Wire.available() < 2)
		;
	data = ((int) Wire.read()) << 8;
	data |= Wire.read();

	return data;
}

/*
i2cWrite16(unsigned int data, unsigned char address) writes 16 bits
of data beginning at an 8-bit address, and continuing to the next.
*/
void i2cWrite16(unsigned int data, unsigned char address)
{
	Wire.beginTransmission(MAX17043_ADDRESS);
	Wire.write(address);
	Wire.write((byte) ((data >> 8) & 0x00FF));
	Wire.write((byte) (data & 0x00FF));
	Wire.endTransmission();
}
