namespace GBCS.GB
{
    public struct Flags
    {
        public bool Zero = false;
        public bool Substract = false;
        public bool HalfCarry = false;
        public bool Carry = false;

        public Flags() { }
    }

    public class CPU
    {
        public byte[] Registers = new byte[8];
        public ushort Pc;
        public ushort Sp;
        public ushort AddressData;
        public Flags Flags = new();

        public bool WasHalted;
        public bool IMEEnabled;

        public Instruction Inst = Instructions.Get(0x0);
        public MemoryManager Mem = new();

        public CPU()
        {
            Pc = 0x100; //https://gbdev.io/pandocs/The_Cartridge_Header.html#0100-0103---entry-point
        }

        public void Step()
        {
            if (!WasHalted)
            {
                byte opcode = Mem.Read(Pc++);
                Inst = Instructions.Get(opcode);
                AddressDataHandlers.Get(Inst.Addr).Invoke(this);
                InstructionsHandlers.Get(Inst.Type).Invoke(this);
            }
        }

        public ushort GetRegister(RegisterType type)
        {
            return type switch
            {
                RegisterType.A => Registers[0],
                RegisterType.B => Registers[1],
                RegisterType.C => Registers[2],
                RegisterType.D => Registers[3],
                RegisterType.E => Registers[4],
                RegisterType.F => Registers[5],
                RegisterType.H => Registers[6],
                RegisterType.L => Registers[7],
                RegisterType.AF => (ushort)((GetRegister(RegisterType.A) << 8) | GetRegister(RegisterType.F)),
                RegisterType.BC => (ushort)((GetRegister(RegisterType.B) << 8) | GetRegister(RegisterType.C)),
                RegisterType.DE => (ushort)((GetRegister(RegisterType.D) << 8) | GetRegister(RegisterType.E)),
                RegisterType.HL => (ushort)((GetRegister(RegisterType.H) << 8) | GetRegister(RegisterType.L)),
                RegisterType.PC => Pc,
                RegisterType.SP => Sp,
                RegisterType.NONE => throw new ArgumentException("Given type isn't a valid register."),
                _ => throw new ArgumentException("Given type isn't a valid register.")
            };
        }

        public void SetRegister(RegisterType type, ushort value)
        {
            switch (type)
            {
                case RegisterType.A: Registers[0] = (byte)(value & 0xFF); break;
                case RegisterType.B: Registers[1] = (byte)(value & 0xFF); break;
                case RegisterType.C: Registers[2] = (byte)(value & 0xFF); break;
                case RegisterType.D: Registers[3] = (byte)(value & 0xFF); break;
                case RegisterType.E: Registers[4] = (byte)(value & 0xFF); break;
                case RegisterType.F: Registers[5] = (byte)(value & 0xFF); break;
                case RegisterType.H: Registers[6] = (byte)(value & 0xFF); break;
                case RegisterType.L: Registers[7] = (byte)(value & 0xFF); break;
                case RegisterType.AF:
                    Registers[0] = (byte)((value & 0xFF00) >> 8);
                    Registers[5] = (byte)(value & 0xFF);
                    break;
                case RegisterType.BC:
                    Registers[1] = (byte)((value & 0xFF00) >> 8);
                    Registers[2] = (byte)(value & 0xFF);
                    break;
                case RegisterType.DE:
                    Registers[3] = (byte)((value & 0xFF00) >> 8);
                    Registers[4] = (byte)(value & 0xFF);
                    break;
                case RegisterType.HL:
                    Registers[6] = (byte)((value & 0xFF00) >> 8);
                    Registers[7] = (byte)(value & 0xFF);
                    break;
                case RegisterType.SP:
                    Sp = value;
                    break;
                case RegisterType.PC:
                    Pc = value;
                    break;
                case RegisterType.NONE:
                    throw new ArgumentException("Given type isn't a valid register.");
                default:
                    throw new ArgumentException("Given type isn't a valid register.");
            }
        }

        public byte FromFlags()
        {
            return (byte)(
                ((Flags.Zero ? 1 : 0) << 7) |
                ((Flags.Substract ? 1 : 0) << 6) |
                ((Flags.HalfCarry ? 1 : 0) << 5) |
                ((Flags.Carry ? 1 : 0) << 4)
                );
        }

        public void SetFlags(byte value)
        {
            Flags.Zero = ((value >> 7) & 0b1) != 0;
            Flags.Substract = ((value >> 6) & 0b1) != 0;
            Flags.HalfCarry = ((value >> 5) & 0b1) != 0;
            Flags.Carry = ((value >> 4) & 0b1) != 0;
        }
    }
}