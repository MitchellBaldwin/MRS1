/*
Mobile Robot System Master Communications Controller (MRS-MCC)
RMB - 11 Jan 2016

Test mode	(0x00)	Measures the position of a potentiometer and report it to back to the PC host
TRex mode	(0x01)	TRex controlled over i2c bus
RC mode		(0x02)	TRex controlled by RC radio

*/

#include <PacketSerial.h>
#include <Wire.h>

#define startbyte 0x0F
#define I2Caddress 0x07
//#define I2Caddress 0x02

#define PACKET_SIZE 30

#define COMM_BUFFER_SIZE 32
#define TREX_COMMAND_BUFFER_SIZE 0x1B
#define TREX_STATUS_BUFFER_SIZE 0x18
#define TEXT_MESSAGE_MAX_SIZE 28

int sensorPin = 0;		// The potentiometer is connected to analog pin A0
int ledPin = 13;		// The LED is connected to digital pin 13

byte mode = 0x00;		// 0x00	Test mode - default
						// 0x01 TRex i2c mode
						// 0x02 TRex RC radio mode

uint8_t inPacket[PACKET_SIZE];
uint8_t outPacket[PACKET_SIZE];

PacketSerial spUSB;
bool newCommandMsgReceived = false;
uint8_t commandMsgReceived = 0x00;

char inBuffer[COMM_BUFFER_SIZE];
byte outBuffer[COMM_BUFFER_SIZE];
byte commandBuffer[TREX_COMMAND_BUFFER_SIZE];
byte statusBuffer[TREX_STATUS_BUFFER_SIZE];

String textMessage;		// Initializing textNessage here does not seem to work...

void setup()			// this function runs once when the program starts
{
	pinMode(ledPin, OUTPUT);

	for (int i = 0; i < PACKET_SIZE; ++i)
	{
		inPacket[i] = 0x00;
		outPacket[i] = 0x00;
	}
	spUSB.setPacketHandler(&OnUSBPacket);
	spUSB.begin(115200);
	
	Wire.begin();				// Set up i2c interface to TRex controller
	Wire.setTimeout(10);

}

void loop()				// this function runs repeatedly after setup() finishes
{
	// If a new message was received, parse it
	if (newCommandMsgReceived)
	{
		ParseCommandMessage();
	}

	// reset new message received flag
	newCommandMsgReceived = false;

	if (mode == 0x00)	// If in Test mode
	{

	}	// End of Test mode

	spUSB.update();		// Let PacketSerial do its thing

	delay(10);			// Take a breather
}

void ToggleUserLED()
{
	if (digitalRead(ledPin) == HIGH)
	{
		digitalWrite(ledPin, LOW);
	}
	else
	{
		digitalWrite(ledPin, HIGH);
	}
}
