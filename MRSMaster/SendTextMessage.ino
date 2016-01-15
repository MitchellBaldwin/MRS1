/*
RMB - Mobile Robot System Master Communications Controller (MRSMCC)

Text message helper functions

*/

void SendTextMessage()
{
	int i;
	unsigned int msgLength;

	outPacket[0x00] = 0x00;							// MRS text message type
	msgLength = strlen(textMessage.c_str());
	if (msgLength > TEXT_MESSAGE_MAX_SIZE)
	{
		msgLength = TEXT_MESSAGE_MAX_SIZE;
	}
	for (i = 0; i < msgLength; ++i)
	{
		outPacket[i + 1] = textMessage[i];
	}
	for (i = msgLength + 2; i < PACKET_SIZE; ++i)	// Pad buffer
	{
		outPacket[i] = 0x00;		
	}

	SendUSBPacket();
}

void WriteText(char* message)
{
	int i;
	unsigned int msgLength;

	outPacket[0x00] = 0x00;							// MRS text message type
	msgLength = strlen(message);
	if (msgLength > TEXT_MESSAGE_MAX_SIZE)
	{
		msgLength = TEXT_MESSAGE_MAX_SIZE;
	}
	for (i = 0; i < msgLength; ++i)
	{
		outPacket[i + 1] = message[i];
	}
	for (i = msgLength + 2; i < PACKET_SIZE; ++i)	// Pad buffer
	{
		outPacket[i] = 0x00;						
	}

	SendUSBPacket();
}

void WriteTextLn(char* message)
{
	int i;
	unsigned int msgLength;

	outPacket[0x00] = 0x00;			                    // MRS text message type
	for (i = 1; i < PACKET_SIZE; ++i)
	{
		outPacket[i] = 0x00;		                    // Pad buffer
	}
	msgLength = strlen(message);
	if (msgLength > TEXT_MESSAGE_MAX_SIZE-2)
	{
		msgLength = TEXT_MESSAGE_MAX_SIZE-2;
	}
	for (i = 0; i < msgLength; ++i)
	{
		outPacket[i + 1] = message[i];
	}
	outPacket[msgLength + 1] = 0x0D;                    // ASCII CR
	outPacket[msgLength + 2] = 0x0A;                    // ASCII LF

	SendUSBPacket();
}
