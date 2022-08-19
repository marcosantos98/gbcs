namespace GBCS.GB
{
    public class MemoryManager
    {
        public byte[] Memory = new byte[0xFFFF];
        public byte[] Serial = new byte[2];

        private readonly CPU _cpu;

        public MemoryManager(CPU cpu)
        {
            _cpu = cpu;
        }

        public ushort ReadU16(ushort address)
        {
            return (ushort)(Read(address) | (Read((ushort)(address + 1)) << 8));
        }

        public byte Read(ushort address)
        {
            if (address < 0x8000)
            {
                //Console.WriteLine("Reading 0x{0:X4} from ROM.", address);
                return Memory[address];
            }
            else if (address < 0xA000)
            {
                //Console.WriteLine("Reading 0x{0:X4} from CharMap.", address);
                return Memory[address];
            }
            else if (address < 0xC000)
            {
                //Console.WriteLine("Reading 0x{0:X4} from External RAM.", address);
                return Memory[address];
            }
            else if (address < 0xE000)
            {
                //Console.WriteLine("Reading 0x{0:X4} from Working RAM.", address);
                return Memory[address];
            }
            else if (address < 0xFE00)
            {
                Console.WriteLine("Reading 0x{0:X4} from ECHO RAM. Prohibited by NITENDO.", address);
                Environment.Exit(1);
            }
            else if (address < 0xFEA0)
            {
                //Console.WriteLine("Reading 0x{0:X4} from OAM.", address);
                return Memory[address];
            }
            else if (address < 0xFF00)
            {
                Console.WriteLine("Reading 0x{0:X4} from Reserved area. Prohibited by NITENDO.", address);
                Environment.Exit(1);
            }
            else if (address < 0xFF80)
            {
                //_cpu.stack.LogLn("Reading 0x{0:X4} from IO Registers.", address);

                if (address == 0xFF01)
                {
                    return Serial[0];
                }
                else if (address == 0xFF02)
                {
                    return Serial[1];
                }

                return Memory[address];
            }
            else if (address == 0xFFFF)
            {
                //Console.WriteLine("Reading 0x{0:X4} from IE Register.", address);
                return _cpu.IERegister;
            }

            _cpu.Stack.LogLn("PC: {2:X4} Reading 0x{0:X4} from High RAM. {1:X2}", address, Memory[address], _cpu.Pc);
            return Memory[address]; //HIRAM
        }

        public void Write(ushort address, byte value)
        {
            if (address < 0x8000)
            {
                //Console.WriteLine("\nWriting 0x{1:X2} to 0x{0:X4} from ROM.", address, value);
                //Environment.Exit(1);
            }
            else if (address < 0xA000)
            {
                //Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from CharMap.", address, value);
                Memory[address] = value;
            }
            else if (address < 0xC000)
            {
                //Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from External RAM.", address, value);
                Memory[address] = value;
            }
            else if (address < 0xE000)
            {
                //Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from Working RAM.", address, value);
                Memory[address] = value;
            }
            else if (address < 0xFE00)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from ECHO RAM. Prohibited by NITENDO.", address, value);
                //Environment.Exit(1);
            }
            else if (address < 0xFEA0)
            {
                //Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from OAM.", address, value);
                Memory[address] = value;
            }
            else if (address < 0xFF00)
            {
                Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from Reserved area. Prohibited by NITENDO.", address,
                    value);
                //Environment.Exit(1);
            }
            else if (address < 0xFF80)
            {
                //_cpu.stack.LogLn("Writing 0x{1:X2} to 0x{0:X4} from IO Registers.", address, value);
                if (address == 0xFF01)
                {
                    Serial[0] = value;
                    return;
                }
                else if (address == 0xFF02)
                {
                    Serial[1] = value;
                    return;
                }
                Memory[address] = value;
            }
            else if (address == 0xFFFF)
            {
                //Console.WriteLine("Writing 0x{1:X2} to 0x{0:X4} from IE Register.", address, value);
                _cpu.IERegister = value;
            }
            else
            {
                _cpu.Stack.LogLn("PC: {2:X4} Writing 0x{1:X2} to 0x{0:X4} from High RAM.", address, value, _cpu.Pc);
                Memory[address] = value;
            }
        }
    }
}