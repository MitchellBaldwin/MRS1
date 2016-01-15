
void MasterReceive()
{//================================================================= Error Checking ==========================================================
  byte d;
  byte bytesReceived = 0;
  int i=0;

  bytesReceived = Wire.requestFrom(I2Caddress,TREX_STATUS_BUFFER_SIZE);				// Request 24 bytes from device I2Caddress
  if (bytesReceived < TREX_STATUS_BUFFER_SIZE)
  {
	  char s[TEXT_MESSAGE_MAX_SIZE];								// Wire.requestFrom should return the number of bytes to receive from
	  snprintf(s, TEXT_MESSAGE_MAX_SIZE, "%db\n", bytesReceived);	//the slave device; NOTE that the bytes are still in the buffer until
	  WriteTextLn(s);                                               //read using Wire.read()
	  											                    // If fewer bytes were received in the buffer then report that number
	  return;                                                       //and return
  }
  
  while(Wire.available()<24)										// wait for entire data packet to be received
  {                                                                 // NOTE: THIS IS BLOCKING CODE!!
  }

  d=Wire.read();													// Read what should be the start byte from buffer
  if(d!=startbyte)													// If start byte not equal to 0x0F                                                    
  {
    //Serial.print(d,DEC);
    while(Wire.available()>0)										// Purge the buffer of all data
    {
      d=Wire.read();
    }
	WriteTextLn("Wrong start byte");                                // Report framing error
	return;															// Quit - no joy
  }
  else
  {
	  statusBuffer[0x00] = d;                                       // Set the first position of statusBuffer to the start byte
  }
  
  //================================================================ Read Data ==============================================================

  for (i = 0; i < TREX_STATUS_BUFFER_SIZE - 1; ++i)
  {
	  statusBuffer[i + 1] = Wire.read();                            // Read the rest of the status info to the statusBuffer; startByte has 
  }                                                                 //already been read (above)

  //Serial.print("Slave Error Message:");                           // slave error report
  //Serial.println(Wire.read(),DEC);
  //
  //i=Wire.read()*256+Wire.read();                                  // T'REX battery voltage
  //Serial.print("Battery Voltage:\t");
  //Serial.print(int(i/10));Serial.println(".");                      
  //Serial.print(i-(int(i/10)*10));Serial.println("V");
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("Left  Motor Current:\t");
  //Serial.print(i);Serial.println("mA");                           // T'REX left  motor current in mA
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("Left  Motor Encoder:\t");
  //Serial.println(i);                                              // T'REX left  motor encoder count
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("Right Motor Current:\t");
  //Serial.print(i);Serial.println("mA");                           // T'REX right motor current in mA
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("Right Motor Encoder:\t");
  //Serial.println(i);                                              // T'REX right motor encoder count
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("X-axis:\t\t");
  //Serial.println(i);                                              // T'REX X-axis
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("Y-axis:\t\t");
  //Serial.println(i);                                              // T'REX Y-axis
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("Z-axis:\t\t");
  //Serial.println(i);                                              // T'REX Z-axis
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("X-delta:\t\t");
  //Serial.println(i);                                              // T'REX X-delta
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("Y-delta:\t\t");
  //Serial.println(i);                                              // T'REX Y-delta
  //
  //i=Wire.read()*256+Wire.read();
  //Serial.print("Z-delta:\t\t");
  //Serial.println(i);                                              // T'REX Z-delta
  //Serial.print("\r\n\n\n");
  
}
  
  
  
  
  
  
  

