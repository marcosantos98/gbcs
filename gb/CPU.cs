namespace GBCS.GB
{
    public class CPU
    {
        public byte RegA, RegB, RegC, RegD, RegE, RegF, RegH, RegL;
        public ushort Pc, Sp;

        public bool IsHalted;
        public byte IERegister;
        public bool InterruptsEnabled;
        public byte InterruptsFlag;

        public IDictionary<ushort, byte> StackHolder = new Dictionary<ushort, byte>();

        private readonly Instructions _instructions;
        public readonly MemoryManager Mem;
        public readonly Log Stack = new("stack");

        public CPU()
        {
            Mem = new(this);
            _instructions = new(this);

            Pc = 0x100;
        }

        public bool Step()
        {
            if (!IsHalted)
            {
                Console.Write("PC: {0:X4} ", Pc);
                ushort oldPc = Pc;
                byte opcode = Mem.Read(Pc++);
                try
                {
                    _ = _instructions.ForOpcode(opcode);
                    Console.WriteLine(
                        " A: {0:X2} BC: {1:X2}{2:X2} DE: {3:X2}{4:X2} HL: {5:X2}{6:X2} F: {7}{8}{9}{10} WD: [{11:X2}, {12:X2}, {13:X2}]",
                        RegA, RegB, RegC, RegD, RegE, RegH, RegL,
                        GetFlags().zero ? "Z" : "-",
                        GetFlags().subs ? "N" : "-",
                        GetFlags().half ? "H" : "-",
                        GetFlags().carry ? "C" : "-",
                        opcode, Mem.Read((ushort)(oldPc + 1)), Mem.Read((ushort)(oldPc + 2))
                    );
                }
                catch (NotImplementedException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    // stack.Clear();

                    // foreach (var val in Stack)
                    // {
                    //     if (Sp == val.Key)
                    //     {
                    //         stack.LogLn("${0:X4}: {1:X2} <-", val.Key, val.Value);
                    //     }
                    //     else
                    //     {
                    //         stack.LogLn("${0:X4}: {1:X2}", val.Key, val.Value);
                    //     }
                    // }


                    Stack.ToFile();
                    Environment.Exit(1);
                }

                return true;
            }

            return true;
        }

        public (bool zero, bool subs, bool half, bool carry) GetFlags()
        {
            return (((RegF >> 7) & 0b1) != 0, ((RegF >> 6) & 0b1) != 0, ((RegF >> 5) & 0b1) != 0,
                ((RegF >> 4) & 0b1) != 0);
        }

        public void SetZeroFlag(bool val)
        {
            if (val)
            {
                RegF |= 1 << 7;
            }
            else
            {
                RegF = (byte)(RegF & ~(1 << 7));
            }
        }

        public void SetSubFlag(bool val)
        {
            if (val)
            {
                RegF |= 1 << 6;
            }
            else
            {
                RegF = (byte)(RegF & ~(1 << 6));
            }
        }

        public void SetHalfCarryFlag(bool val)
        {
            if (val)
            {
                RegF |= 1 << 5;
            }
            else
            {
                RegF = (byte)(RegF & ~(1 << 5));
            }
        }

        public void SetCarryFlag(bool val)
        {
            if (val)
            {
                RegF |= 1 << 4;
            }
            else
            {
                RegF = (byte)(RegF & ~(1 << 4));
            }
        }
    }
}