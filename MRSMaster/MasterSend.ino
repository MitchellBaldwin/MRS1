void MasterSend()
{
	int i;

	//char s[TEXT_MESSAGE_MAX_SIZE];
	//snprintf(s, TEXT_MESSAGE_MAX_SIZE, "%#x %#x %#x %#x %#x %#x %#x %#x\n", commandBuffer[0x00], commandBuffer[0x01], commandBuffer[0x02], commandBuffer[0x03], commandBuffer[0x04], commandBuffer[0x05], commandBuffer[0x06], commandBuffer[0x07]);	//the slave device
	//textMessage = s;
	//SendTextMessage();

	Wire.beginTransmission(I2Caddress);

	Wire.write(commandBuffer, TREX_COMMAND_BUFFER_SIZE);

	//for (i = 0; i < TREX_COMMAND_BUFFER_SIZE; ++i)
	//{
	//	Wire.write(commandBuffer[i]);
	//	delay(2);
	//}
	Wire.endTransmission();

	//-------------------------------- Make sure Master and Slave I2C clock the same ------------------------------------------------

	if (commandBuffer[TREX_COMMAND_BUFFER_SIZE - 1] == 0x00)    // thanks to Nick Gammon: http://gammon.com.au/i2c
	{
		TWBR=72;												// default I²C clock is 100kHz
	}
	else
	{
		TWBR=12;												// changes the I²C clock to 400kHz
	}
}
