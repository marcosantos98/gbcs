namespace GBCS.GB
{



    public class InterruptHandlers
    {

        public static readonly byte VBLANK = 1;
        public static readonly byte LCD_START = 2;
        public static readonly byte TIMER = 4;
        public static readonly byte SERIAL = 8;
        public static readonly byte JOYPAD = 16;

        private static bool CheckInterrup(CPU cpu, ushort address, byte flag)
        {
            if (Convert.ToBoolean(cpu.InterruptsFlag & flag) && Convert.ToBoolean(cpu.IERegister & flag))
            {
                cpu.PushU16(address);
                cpu.Pc = address;
                cpu.InterruptsFlag &= (byte)~flag;
                cpu.WasHalted = false;
                cpu.IMEEnabled = false;
                return true;
            }
            return false;
        }

        public static void HandleInterrupt(CPU cpu)
        {
            if (CheckInterrup(cpu, 0x40, VBLANK))
            {

            }
            else if (CheckInterrup(cpu, 0x48, LCD_START))
            {

            }
            else if (CheckInterrup(cpu, 0x50, TIMER))
            {

            }
            else if (CheckInterrup(cpu, 0x58, SERIAL))
            {

            }
            else if (CheckInterrup(cpu, 0x60, JOYPAD))
            {

            }
        }
    }
}