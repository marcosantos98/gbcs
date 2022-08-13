using GB.Types;

namespace GB
{
    public struct Flags
    {
        public bool zero = false;
        public bool substract = false;
        public bool halfCarry = false;
        public bool carry = false;

        public Flags() { }
    }

    public class CPU
    {
        public byte[] registers = new byte[8];
        public ushort pc;
        public ushort sp;
        public Flags flags = new Flags();

        public Instruction inst = Instructions.instructions[0x0];

        public ushort GetRegister(RegisterType type)
        {
            return type switch
            {
                RegisterType.A => registers[0],
                RegisterType.B => registers[1],
                RegisterType.C => registers[2],
                RegisterType.D => registers[3],
                RegisterType.E => registers[4],
                RegisterType.F => registers[5],
                RegisterType.H => registers[6],
                RegisterType.L => registers[7],
                RegisterType.AF => (ushort)((GetRegister(RegisterType.A) << 8) | GetRegister(RegisterType.F)),
                RegisterType.BC => (ushort)((GetRegister(RegisterType.B) << 8) | GetRegister(RegisterType.C)),
                RegisterType.DE => (ushort)((GetRegister(RegisterType.D) << 8) | GetRegister(RegisterType.E)),
                RegisterType.HL => (ushort)((GetRegister(RegisterType.H) << 8) | GetRegister(RegisterType.L)),
                RegisterType.PC => pc,
                RegisterType.SP => sp,
                _ => throw new ArgumentException("Given type isn't a valid register.")
            };
        }

        public void SetRegister(RegisterType type, ushort value)
        {
            switch (type)
            {
                case RegisterType.A: registers[0] = (byte)(value & 0xFF); break;
                case RegisterType.B: registers[1] = (byte)(value & 0xFF); break;
                case RegisterType.C: registers[2] = (byte)(value & 0xFF); break;
                case RegisterType.D: registers[3] = (byte)(value & 0xFF); break;
                case RegisterType.E: registers[4] = (byte)(value & 0xFF); break;
                case RegisterType.F: registers[5] = (byte)(value & 0xFF); break;
                case RegisterType.H: registers[6] = (byte)(value & 0xFF); break;
                case RegisterType.L: registers[7] = (byte)(value & 0xFF); break;
                case RegisterType.AF:
                    registers[0] = (byte)((value & 0xFF00) >> 8);
                    registers[5] = (byte)(value & 0xFF);
                    break;
                case RegisterType.BC:
                    registers[1] = (byte)((value & 0xFF00) >> 8);
                    registers[2] = (byte)(value & 0xFF);
                    break;
                case RegisterType.DE:
                    registers[3] = (byte)((value & 0xFF00) >> 8);
                    registers[4] = (byte)(value & 0xFF);
                    break;
                case RegisterType.HL:
                    registers[6] = (byte)((value & 0xFF00) >> 8);
                    registers[7] = (byte)(value & 0xFF);
                    break;
            }
        }

        public byte FromFlags()
        {
            return (byte)(
                (flags.zero ? 1 : 0) << 7 |
                (flags.substract ? 1 : 0) << 6 |
                (flags.halfCarry ? 1 : 0) << 5 |
                (flags.carry ? 1 : 0) << 4
                );
        }

        public void SetFlags(byte value)
        {
            flags.zero = ((value >> 7) & 0b1) != 0;
            flags.substract = ((value >> 6) & 0b1) != 0;
            flags.halfCarry = ((value >> 5) & 0b1) != 0;
            flags.carry = ((value >> 4) & 0b1) != 0;
        }
    }
}