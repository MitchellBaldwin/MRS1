using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRS1
{
    class TRex
    {
        public const Byte TREX_COMMAND_BUFFER_SIZE = 0x1B;      // 27 DEC
        public const Byte TREX_STATUS_BUFFER_SIZE = 0x18;       // 24 DEC

        public Byte[] CommandBuffer = new byte[TREX_COMMAND_BUFFER_SIZE];
        public Byte[] StatusBuffer = new byte[TREX_STATUS_BUFFER_SIZE];
        
        public const Byte CommStartByte = 0x0F;

        #region Command properties

        Byte pwmFreq = 0x06;
        public Byte PWMFreq
        {
            get { return pwmFreq; }
            set
            { 
                pwmFreq = value;
                CommandBuffer[(Byte)CommandBytes.PWMFreq] = pwmFreq;
            }
        }

        Int16 lMotSpeed = 0x0000;
        public Int16 LMotSpeed
        {
            get { return lMotSpeed; }
            set
            {
                lMotSpeed = value;
                CommandBuffer[(Byte)CommandBytes.LMotHi] = (Byte)(lMotSpeed >> 8);
                CommandBuffer[(Byte)CommandBytes.LMotLo] = (Byte)(lMotSpeed & 0x00FF);
            }
        }

        Byte lMotBreak = 0x00;
        public Byte LMotBreak
        {
            get { return lMotBreak; }
            set
            {
                lMotBreak = value;
                CommandBuffer[(Byte)CommandBytes.LMotBreak] = lMotBreak;
            }
        }

        Int16 rMotSpeed = 0x0000;
        public Int16 RMotSpeed
        {
            get { return rMotSpeed; }
            set
            {
                rMotSpeed = value;
                CommandBuffer[(Byte)CommandBytes.RMotHi] = (Byte)(rMotSpeed >> 8);
                CommandBuffer[(Byte)CommandBytes.RMotLo] = (Byte)(rMotSpeed & 0x00FF);
            }
        }

        Byte rMotBreak = 0x00;
        public Byte RMotBreak
        {
            get { return rMotBreak; }
            set
            {
                rMotBreak = value;
                CommandBuffer[(Byte)CommandBytes.RMotBreak] = rMotBreak;
            }
        }

        Int16 servo0 = 1500;
        public Int16 Servo0
        {
            get { return servo0; }
            set
            {
                servo0 = value;
                CommandBuffer[(Byte)CommandBytes.Servo0Hi] = (Byte)(servo0 >> 8);
                CommandBuffer[(Byte)CommandBytes.Servo0Lo] = (Byte)(servo0 & 0x00FF);
            }
        }

        Int16 servo1 = 1500;
        public Int16 Servo1
        {
            get { return servo1; }
            set
            {
                servo1 = value;
                CommandBuffer[(Byte)CommandBytes.Servo1Hi] = (Byte)(servo1 >> 8);
                CommandBuffer[(Byte)CommandBytes.Servo1Lo] = (Byte)(servo1 & 0x00FF);
            }
        }

        Int16 servo2 = 1500;
        public Int16 Servo2
        {
            get { return servo2; }
            set
            {
                servo2 = value;
                CommandBuffer[(Byte)CommandBytes.Servo2Hi] = (Byte)(servo2 >> 8);
                CommandBuffer[(Byte)CommandBytes.Servo2Lo] = (Byte)(servo2 & 0x00FF);
            }
        }

        Int16 servo3 = 1500;
        public Int16 Servo3
        {
            get { return servo3; }
            set
            {
                servo3 = value;
                CommandBuffer[(Byte)CommandBytes.Servo3Hi] = (Byte)(servo3 >> 8);
                CommandBuffer[(Byte)CommandBytes.Servo3Lo] = (Byte)(servo3 & 0x00FF);
            }
        }

        Int16 servo4 = 0;
        public Int16 Servo4
        {
            get { return servo4; }
            set
            {
                servo4 = value;
                CommandBuffer[(Byte)CommandBytes.Servo4Hi] = (Byte)(servo4 >> 8);
                CommandBuffer[(Byte)CommandBytes.Servo4Lo] = (Byte)(servo4 & 0x00FF);
            }
        }

        Int16 servo5 = 0;
        public Int16 Servo5
        {
            get { return servo5; }
            set
            {
                servo5 = value;
                CommandBuffer[(Byte)CommandBytes.Servo5Hi] = (Byte)(servo5 >> 8);
                CommandBuffer[(Byte)CommandBytes.Servo5Lo] = (Byte)(servo5 & 0x00FF);
            }
        }

        Byte accelDV = 50;
        public Byte AccelDV
        {
            get { return accelDV; }
            set {
                accelDV = value;
                CommandBuffer[(Byte)CommandBytes.AccelDV] = accelDV;
            }
        }

        Int16 impSen = 50;
        public Int16 ImpSen
        {
            get { return impSen; }
            set
            {
                impSen = value;
                CommandBuffer[(Byte)CommandBytes.ImpSenHi] = (Byte)(impSen >> 8);
                CommandBuffer[(Byte)CommandBytes.ImpSenLo] = (Byte)(impSen & 0x00FF);
            }
        }

        Int16 loBat = 550;
        public Int16 LoBat
        {
            get { return loBat; }
            set
            {
                loBat = value;
                CommandBuffer[(Byte)CommandBytes.LoBatHi] = (Byte)(loBat >> 8);
                CommandBuffer[(Byte)CommandBytes.LoBatLo] = (Byte)(loBat & 0x00FF);
            }
        }

        Byte i2CAddr = 0x07;

        public Byte I2CAddr
        {
            get { return i2CAddr; }
            set
            {
                i2CAddr = value;
                CommandBuffer[(Byte)CommandBytes.I2CAddr] = i2CAddr;
            }
        }

        Byte i2CClkFreq = 0x00;
        public Byte I2CClkFreq
        {
            get { return i2CClkFreq; }
            set
            {
                i2CClkFreq = value;
                CommandBuffer[(Byte)CommandBytes.I2CClkFreq] = i2CClkFreq;
            }
        }

        #endregion  // Command properties

        #region Status properties

        Byte error = 0x00;
        public Byte Error
        {
            get { return error; }
            set { error = value; }
        }

        Int16 batV = 0x0000;
        public Int16 BatV
        {
            get 
            {
                batV = (Int16)(StatusBuffer[(int)StatusBytes.BatVHi] * 256 + StatusBuffer[(int)StatusBytes.BatVLo]);
                return batV; 
            }
            set
            {
                batV = value;
            }
        }

        Int16 lMotI = 0x0000;
        public Int16 LMotI
        {
            get 
            {
                lMotI = (Int16)(StatusBuffer[(int)StatusBytes.LMotIHi] * 256 + StatusBuffer[(int)StatusBytes.LMotILo]);
                return lMotI; 
            }
            set { lMotI = value; }
        }

        Int16 lEnc = 0x0000;
        public Int16 LEnc
        {
            get 
            {
                lEnc = (Int16)(StatusBuffer[(int)StatusBytes.LEncHi] * 256 + StatusBuffer[(int)StatusBytes.LEncLo]);
                return lEnc; 
            }
            set { lEnc = value; }
        }

        Int16 rMotI = 0x0000;
        public Int16 RMotI
        {
            get
            {
                rMotI = (Int16)(StatusBuffer[(int)StatusBytes.RMotIHi] * 256 + StatusBuffer[(int)StatusBytes.RMotILo]);
                return rMotI; 
            }
            set { rMotI = value; }
        }

        Int16 rEnc = 0x0000;
        public Int16 REnc
        {
            get 
            { 
                return rEnc;
                rEnc = (Int16)(StatusBuffer[(int)StatusBytes.REncHi] * 256 + StatusBuffer[(int)StatusBytes.REncLo]);
            }
            set { rEnc = value; }
        }

        Int16 accelX = 0x0000;
        public Int16 AccelX
        {
            get
            {
                accelX = (Int16)(StatusBuffer[(int)StatusBytes.AccelXHi] * 256 + StatusBuffer[(int)StatusBytes.AccelXLo]);
                return accelX;
            }
            set { accelX = value; }
        }

        Int16 accelY = 0x0000;
        public Int16 AccelY
        {
            get
            {
                accelY = (Int16)(StatusBuffer[(int)StatusBytes.AccelYHi] * 256 + StatusBuffer[(int)StatusBytes.AccelYLo]);
                return accelY;
            }
            set { accelY = value; }
        }

        Int16 accelZ = 0x0000;
        public Int16 AccelZ
        {
            get
            {
                accelZ = (Int16)(StatusBuffer[(int)StatusBytes.AccelZHi] * 256 + StatusBuffer[(int)StatusBytes.AccelZLo]);
                return accelZ;
            }
            set { accelZ = value; }
        }

        Int16 impX = 0x0000;
        public Int16 ImpX
        {
            get
            {
                impX = (Int16)(StatusBuffer[(int)StatusBytes.ImpXHi] * 256 + StatusBuffer[(int)StatusBytes.ImpXLo]);
                return impX;
            }
            set { impX = value; }
        }

        Int16 impY = 0x0000;
        public Int16 ImpY
        {
            get
            {
                impY = (Int16)(StatusBuffer[(int)StatusBytes.ImpYHi] * 256 + StatusBuffer[(int)StatusBytes.ImpYLo]);
                return impY;
            }
            set { impY = value; }
        }

        Int16 impZ = 0x0000;
        public Int16 ImpZ
        {
            get
            {
                impZ = (Int16)(StatusBuffer[(int)StatusBytes.ImpZHi] * 256 + StatusBuffer[(int)StatusBytes.ImpZLo]);
                return impZ;
            }
            set { impZ = value; }
        }

        #endregion // Status properties

        public enum CommandBytes
        {
            Start = 0x00,
            PWMFreq = 0x01,
            LMotHi = 0x02,
            LMotLo = 0x03,
            LMotBreak = 0x04,
            RMotHi = 0x05,
            RMotLo = 0x06,
            RMotBreak = 0x07,
            Servo0Hi = 0x08,
            Servo0Lo = 0x09,
            Servo1Hi = 0x0A,
            Servo1Lo = 0x0B,
            Servo2Hi = 0x0C,
            Servo2Lo = 0x0D,
            Servo3Hi = 0x0E,
            Servo3Lo = 0x0F,
            Servo4Hi = 0x10,
            Servo4Lo = 0x11,
            Servo5Hi = 0x12,
            Servo5Lo = 0x13,
            AccelDV = 0x14,
            ImpSenHi = 0x15,
            ImpSenLo = 0x16,
            LoBatHi = 0x17,
            LoBatLo = 0x18,
            I2CAddr = 0x19,
            I2CClkFreq = 0x1A
        }

        public enum StatusBytes
        {
            Start = 0x00,
            Error = 0x01,
            BatVHi = 0x02,
            BatVLo = 0x03,
            LMotIHi = 0x04,
            LMotILo = 0x05,
            LEncHi = 0x06,
            LEncLo = 0x07,
            RMotIHi = 0x08,
            RMotILo = 0x09,
            REncHi = 0x0A,
            REncLo = 0x0B,
            AccelXHi = 0x0C,
            AccelXLo = 0x0D,
            AccelYHi = 0x0E,
            AccelYLo = 0x0F,
            AccelZHi = 0x10,
            AccelZLo = 0x11,
            ImpXHi = 0x12,
            ImpXLo = 0x13,
            ImpYHi = 0x14,
            ImpYLo = 0x15,
            ImpZHi = 0x16,
            ImpZLo = 0x17
        }

        // Throttle & Steering properties
        Int16 throttle = 0x0000;
        public Int16 Throttle
        {
            get 
            { 
                return throttle;
            }
            set 
            { 
                throttle = value;
                LMotSpeed = (Int16)(throttle - steering);
                RMotSpeed = (Int16)(throttle + steering);
            }
        }

        // TRex steering setting - negative values indicate a left turn, positive values a right turn
        Int16 steering = 0x0000;
        public Int16 Steering
        {
            get 
            { 
                return steering; 
            }
            set 
            { 
                steering = value;
                // Use the TRexThrottle setter to adjust relative L & R motor speeds according to the
                // new steering setting
                Throttle = throttle;
            }
        }
        
        //
        // Default constructor
        //
        public TRex()
        {
            // Initialize the command buffer with the default values
            CommandBuffer[0x00] = CommStartByte;
            CommandBuffer[(Byte)CommandBytes.PWMFreq] = pwmFreq;
            CommandBuffer[(Byte)CommandBytes.LMotHi] = (Byte)(lMotSpeed >> 8);
            CommandBuffer[(Byte)CommandBytes.LMotLo] = (Byte)(lMotSpeed & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.LMotBreak] = lMotBreak;
            CommandBuffer[(Byte)CommandBytes.RMotHi] = (Byte)(rMotSpeed >> 8);
            CommandBuffer[(Byte)CommandBytes.RMotLo] = (Byte)(rMotSpeed & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.RMotBreak] = rMotBreak;
            CommandBuffer[(Byte)CommandBytes.Servo0Hi] = (Byte)(servo0 >> 8);
            CommandBuffer[(Byte)CommandBytes.Servo0Lo] = (Byte)(servo0 & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.Servo1Hi] = (Byte)(servo1 >> 8);
            CommandBuffer[(Byte)CommandBytes.Servo1Lo] = (Byte)(servo1 & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.Servo2Hi] = (Byte)(servo2 >> 8);
            CommandBuffer[(Byte)CommandBytes.Servo2Lo] = (Byte)(servo2 & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.Servo3Hi] = (Byte)(servo3 >> 8);
            CommandBuffer[(Byte)CommandBytes.Servo3Lo] = (Byte)(servo3 & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.Servo4Hi] = (Byte)(servo4 >> 8);
            CommandBuffer[(Byte)CommandBytes.Servo4Lo] = (Byte)(servo4 & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.Servo5Hi] = (Byte)(servo5 >> 8);
            CommandBuffer[(Byte)CommandBytes.Servo5Lo] = (Byte)(servo5 & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.AccelDV] = accelDV;
            CommandBuffer[(Byte)CommandBytes.ImpSenHi] = (Byte)(impSen >> 8);
            CommandBuffer[(Byte)CommandBytes.ImpSenLo] = (Byte)(impSen & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.LoBatHi] = (Byte)(loBat >> 8);
            CommandBuffer[(Byte)CommandBytes.LoBatLo] = (Byte)(loBat & 0x00FF);
            CommandBuffer[(Byte)CommandBytes.I2CAddr] = i2CAddr;
            CommandBuffer[(Byte)CommandBytes.I2CClkFreq] = i2CClkFreq;
        }

        //
        // Parse the Status buffer and store status iinfo in corresponding properties
        //
        public void ParseStatusBuffer()
        {
            // Helper function not needed; 
            // Property getters decode status parameters from the StatusBuffer

        }
    }
}
