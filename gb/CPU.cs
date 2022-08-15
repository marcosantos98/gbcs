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
        public byte Opcode;
        public ushort AddressData;
        public Flags Flags = new();

        public bool WasHalted;
        public bool IMEEnabled;

        public ushort MemDest;
        public bool PcIsMemDest;

        public Instruction Inst = Instructions.Get(0x0);
        public MemoryManager Mem = new();

        private readonly StringWriter _writer = new();

        public CPU()
        {
            Pc = 0x100; //https://gbdev.io/pandocs/The_Cartridge_Header.html#0100-0103---entry-point
        }

        public bool Step()
        {
            if (!WasHalted)
            {
                MemDest = 0;
                PcIsMemDest = false;

                _writer.WriteLine("> PC: {0:X4}", Pc);

                Opcode = Mem.Read(Pc++);

                Inst = Instructions.Get(Opcode);

                _writer.WriteLine("    Opcode: {0:X2} NextTwo: {1:X2} {2:X2} AddressData: {3:X4}", Opcode, Mem.Read(Pc), Mem.Read((ushort)(Pc + 1)), AddressData);
                _writer.WriteLine("    Inst:{0}, {1}, {2}, {3}, {4}", Inst.Type, Inst.Addr, Inst.RegOne, Inst.RegTwo, Inst.Cond);
                _writer.WriteLine("    REG: AF:{0:X2}{1:X2},BC:{2:X2}{3:X2},DE:{4:X2}{5:X2},HL:{6:X2}{7:X2}",
                 GetRegister(RegisterType.A), GetRegister(RegisterType.F), GetRegister(RegisterType.B), GetRegister(RegisterType.B), GetRegister(RegisterType.D), GetRegister(RegisterType.E), GetRegister(RegisterType.H), GetRegister(RegisterType.H)
                );

                Action<CPU>? addressHandler = AddressDataHandlers.Get(Inst.Addr);

                if (addressHandler == null)
                {
                    Console.WriteLine("Address not implemented!");
                    Console.Write(_writer.ToString());
                    return false;
                }
                else
                {
                    addressHandler.Invoke(this);
                }

                Action<CPU>? instHandler = InstructionsHandlers.Get(Inst.Type);

                if (instHandler == null)
                {
                    Console.WriteLine("Instruction not implemented!");
                    Console.Write(_writer.ToString());
                    return false;
                }
                else
                {
                    instHandler.Invoke(this);
                }

                _ = _writer.GetStringBuilder().Remove(0, _writer.GetStringBuilder().Length);

                return true;
            }
            return true;
        }

        public void Push(byte val)
        {
            Sp--;
            Mem.Write(Sp, val);
        }

        public byte Pop()
        {
            return Mem.Read(Sp++);
        }


        public bool ValidateInstCondition()
        {
            return Inst.Cond switch
            {
                ConditionType.NONE => true,
                ConditionType.NZ => !Flags.Zero,
                ConditionType.Z => Flags.Zero,
                ConditionType.NC => !Flags.Carry,
                ConditionType.C => Flags.Carry,
                _ => throw new NotImplementedException()
            };
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
                RegisterType.NONE => throw new ArgumentException("Read: Given type isn't a valid register. " + type),
                _ => throw new ArgumentException("Read: Given type isn't a valid register. " + type)
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
                    throw new ArgumentException("Write: Given type isn't a valid register. " + type);
                default:
                    throw new ArgumentException("Write: Given type isn't a valid register. " + type);
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