/*
RMB - Mobile Robot System Master Communications Controller (MRSMCC)

Command parsing
Command handling

*/

void ParseCommandMessage()
{
	int i, sensorValue;
	byte checkSum, msgType;
	unsigned int msgLength;

	if (newCommandMsgReceived)
	{
		// Check message type; if it directs a mode change then set new mode and proceed accordingly

		switch (commandMsgReceived)
		{
		case 0x00:		// Incoming text message message

			for (i = 0; i < TEXT_MESSAGE_MAX_SIZE; ++i)
			{
				textMessage[i] = (char) inPacket[i + 1];
			}
			break;

		case 0x01:		// Set operating mode message type

			mode = inPacket[0x01];
			if (mode == 0x00)
			{
				WriteTextLn("Entering Test mode");
			}
			else if (mode == 0x01)
			{
				WriteTextLn("Entering i2c mode");
			}
			else if (mode == 0x02)
			{
				WriteTextLn("Entering RC mode");
			}
			break;

		case 0x10:		// Incoming TRex command message type

			for (i = 0; i < TREX_COMMAND_BUFFER_SIZE; ++i)
			{
				commandBuffer[i] = inPacket[i + 1];
			}

			if (mode == 0x00)						// If in Test mode do not use i2c; instead, echo first 8 bytes back to host
			{
				char s[TEXT_MESSAGE_MAX_SIZE];
				snprintf(s, TEXT_MESSAGE_MAX_SIZE, "CMD: %02x %02x %02x %02x %02x %02x\n", commandBuffer[0x00], commandBuffer[0x01], commandBuffer[0x02], commandBuffer[0x03], commandBuffer[0x04], commandBuffer[0x05]);
				WriteTextLn(s);
			}
			else if (mode == 0x01)                  // If in i2c mode send command to motor controller
			{
				MasterSend();
			}
			break;

		case 0x11:		// TRex status request message type

			if (mode == 0x00)								// In in Test mode do not use i2c; instead return a simulated status message
			{
				// Build and send simulated TRex status message
				sensorValue = analogRead(sensorPin);

				outPacket[0x00] = 0x11;						// MRS TRex status message type
				outPacket[0x01] = startbyte;				// TRex status Start byte - CHECK THIS!!! TRex data sheet has contradictory info
				outPacket[0x02] = 0x00;						// TRex error flags
				outPacket[0x03] = highByte(sensorValue);	// TRex Batt V Hi byte - echo pot measurement to test
				outPacket[0x04] = lowByte(sensorValue);		// TRex Batt V Lo byte - echo pot measurement to test
				outPacket[0x05] = inBuffer[0x04];			// TRex L Mot I Hi byte - echo L Mot setting to test
				outPacket[0x06] = inBuffer[0x05];			// TRex L Mot I Lo byte - echo L Mot setting to test
				outPacket[0x07] = 0x00;						// TRex L Enc Hi byte
				outPacket[0x08] = 0x00;						// TRex L Enc Lo byte
				outPacket[0x09] = inBuffer[0x07];			// TRex R Mot I Hi byte - echo R Mot setting to test
				outPacket[0x0A] = inBuffer[0x08];			// TRex R Mot I Lo byte - echo R Mot setting to test
				outPacket[0x0B] = 0x00;						// TRex R Enc Hi byte
				outPacket[0x0C] = 0x00;						// TRex R Enc Lo byte
				outPacket[0x0D] = 0x00;			            // TRex Accel X Hi byte - test value
				outPacket[0x0E] = 0x64;			            // TRex Accel X Lo byte 
				for (i = 0x0F; i < PACKET_SIZE; ++i)
				{
					outPacket[i] = 0x00;
				}
				SendUSBPacket();
			}
			else
			{
				MasterReceive();
				outPacket[0x00] = 0x11;							// MRS TRex status message type
				for (i = 0; i < TREX_STATUS_BUFFER_SIZE; ++i)
				{
					outPacket[i + 1] = statusBuffer[i];
				}
				for (i = TREX_STATUS_BUFFER_SIZE; i < PACKET_SIZE - 1; ++i)
				{
					outPacket[i] = 0x00;
				}
				SendUSBPacket();
			}
			break;

		default:		// Message type not recognized

			WriteText("Invalid message type");
			break;

		}
	}

}

