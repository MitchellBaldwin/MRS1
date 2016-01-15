
/*
RMB - Mobile Robot System Master Communications Controller (MRSMCC)

Serial communications handlers and helper functions

*/

void OnUSBPacket(const uint8_t* buffer, size_t size)
{
	// Calculate and test checksum; if test fails purge buffer, set newCommangMsgReceived flag false, and return
	uint8_t checksum = 0;
	for (int i = 0; i < PACKET_SIZE - 1; ++i)
	{
		checksum += buffer[i];
	}
	if (checksum != buffer[PACKET_SIZE - 1])
	{
		// Indicate checksum error to host and and other appropriate clients
		// e.g., text message back to host, LED indicating error status, etc.
		char s[TEXT_MESSAGE_MAX_SIZE];
		snprintf(s, TEXT_MESSAGE_MAX_SIZE, "MRS-MCC checksum %#x != %#x", checksum, buffer[PACKET_SIZE - 1]);
		WriteTextLn(s);
		return;
	}

	// Transfer incomming buffer contents (including message type and checksum)	to inPacket
	for (int i = 0; i < PACKET_SIZE; ++i)
	{
		inPacket[i] = buffer[i];
	}

	// Determine message type
	commandMsgReceived = buffer[0];

	// Set new message received flag
	newCommandMsgReceived = true;

	// Test code:
	if (buffer[0] == 0x10)				// Test case
	{
		ToggleUserLED();
		//outPacket[0] = buffer[0] + 1;
		//outPacket[1] = buffer[1] + 1;
		//outPacket[2] = buffer[2] + 1;
		//outPacket[3] = buffer[3] + 1;
		//SendUSBPacket();
	}
}

void SendUSBPacket()
{
	int checksum = 0;
	for (int i = 0; i < PACKET_SIZE - 1; ++i)
	{
		checksum += outPacket[i];
	}
	outPacket[PACKET_SIZE - 1] = checksum;
	spUSB.send(outPacket, PACKET_SIZE);
}

