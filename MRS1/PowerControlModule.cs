using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRS1
{
    class PowerControlModule
    {
        public const Byte COMMAND_BUFFER_SIZE = MRS1.PACKET_SIZE - 1;
        public const Byte STATUS_BUFFER_SIZE = MRS1.PACKET_SIZE - 1;

        public Byte[] CommandBuffer = new byte[COMMAND_BUFFER_SIZE];
        public Byte[] StatusBuffer = new byte[STATUS_BUFFER_SIZE];

        public enum StatusFlagBits
        {
            ExtPow = 0x01,          // External (charge) power connected (R)
            LiPoLow = 0x02,         // Alert status from MAX17043; LiPo remaining charge < LiPoBingo (R)
            Batt1 = 0x04,           // Battery 1 enable (W)
            Batt2 = 0x08,           // Battery 2 enable (W)
            MotPow = 0x10,          // Motor controller enable (W)
            STPow = 0x20,           // Sensor Turret power enable (W)
            SFB40 = 0x40,
            SFB80 = 0x80
        }

        public enum CommandBytes
        {
            StatusFlags = 0x00,     // See StatusFlagBits
            LiPoBingo = 0x01,       // Alert level setting to MAX17043; 32% - 100% (<32% = 32%)
            LiPoSOCLo = 0x02,       // LiPo state of charge from MAX17043
            LiPoSOCHi = 0x03,
            LiPoVLo = 0x04,         // LiPo voltage from MAX17043
            LiPoVHi = 0x05,
            LiPoChrgRate = 0x06,    // Charge rate setting to MCP42010 / MAX17043 (0x00 - 0xFF)
            ExtPowVLo = 0x07,       // External power voltage from PCM MCU ADC
            ExtPowVHi = 0x08,
            Batt1VLo = 0x09,        // Battery 1 voltage from PCM MCU ADC
            Batt1VHi = 0x0A,
            Batt2VLo = 0x0B,        // Battery 2 voltage from PCM MCU ADC
            Batt2VHi = 0x0C

        }

        private bool extPowOn;
        public bool ExtPowOn
        {
            get
            {
                if (((StatusBuffer[(byte)CommandBytes.StatusFlags] & (byte)StatusFlagBits.ExtPow)) != 0x00)
                {
                    extPowOn = true;
                }
                else
                {
                    extPowOn = false;
                }
                return extPowOn;
            }
            //set { extPowOn = value; }     // Read only
        }


    }
}
