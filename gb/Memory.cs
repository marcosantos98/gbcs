namespace GBCS.GB
{
    public class MemoryManager
    {

        public byte[] Memory = new byte[0xFFFF + 0x0001];

        public byte Read(ushort address)
        {
            if (address < 0x8000)
            {
                //Console.WriteLine("Reading 0x{0:X4} from ROM.", address);
                return Memory[address];
            }
            else if (address < 0xA000)
            {
                Console.WriteLine("Reading 0x{0:X4} from CharMap.", address);
                return Memory[address];
            }
            else if (address < 0xC000)
            {
                Console.WriteLine("Reading 0x{0:X4} from External RAM.", address);
                return Memory[address];
            }
            else if (address < 0xE000)
            {
                Console.WriteLine("Reading 0x{0:X4} from Working RAM.", address);
                return Memory[address];
            }
            else if (address < 0xFE00)
            {
                Console.WriteLine("Reading 0x{0:X4} from ECHO RAM. Prohibited by NITENDO.", address);
                Environment.Exit(1);
            }
            else if (address < 0xFEA0)
            {
                Console.WriteLine("Reading 0x{0:X4} from OAM.", address);
                return Memory[address];
            }
            else if (address < 0xFF00)
            {
                Console.WriteLine("Reading 0x{0:X4} from Reserved area. Prohibited by NITENDO.", address);
                Environment.Exit(1);
            }
            else if (address < 0xFF80)
            {
                Console.WriteLine("Reading 0x{0:X4} from IO Registers.", address);
                return Memory[address];
            }
            else if (address == 0xFFFF)
            {
                Console.WriteLine("Reading 0x{0:X4} from IE Register.", address);
                return Memory[address];
            }
            Console.WriteLine("Reading 0x{0:X4} from High RAM.", address);
            return Memory[address]; //HIRAM
        }

        public void Write(ushort address, byte value)
        {
            if (address < 0x8000)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from ROM.", address, value);
                Environment.Exit(1);
            }
            else if (address < 0xA000)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from CharMap.", address, value);
                Memory[address] = value;
            }
            else if (address < 0xC000)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from External RAM.", address, value);
                Memory[address] = value;
            }
            else if (address < 0xE000)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from Working RAM.", address, value);
                Memory[address] = value;
            }
            else if (address < 0xFE00)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from ECHO RAM. Prohibited by NITENDO.", address, value);
                Environment.Exit(1);
            }
            else if (address < 0xFEA0)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from OAM.", address, value);
                Memory[address] = value;
            }
            else if (address < 0xFF00)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from Reserved area. Prohibited by NITENDO.", address, value);
                Environment.Exit(1);
            }
            else if (address < 0xFF80)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from IO Registers.", address, value);
                Memory[address] = value;
            }
            else if (address == 0xFFFF)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from IE Register.", address, value);
                Memory[address] = value;
            }
            else
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from High RAM.", address, value);
                Memory[address] = value;
            }
        }
    }
}