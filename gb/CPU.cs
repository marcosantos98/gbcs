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

        public byte GetU8Register(RegisterType type)
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
                _ => throw new ArgumentException("Given type isn't a valid 8bit register. Try GetU16Register instead.")
            };
        }

        public ushort GetU16Register(RegisterType type)
        {
            return type switch
            {
                RegisterType.AF => (ushort)((GetU8Register(RegisterType.A) << 8) | GetU8Register(RegisterType.F)),
                RegisterType.BC => (ushort)((GetU8Register(RegisterType.B) << 8) | GetU8Register(RegisterType.C)),
                RegisterType.DE => (ushort)((GetU8Register(RegisterType.D) << 8) | GetU8Register(RegisterType.E)),
                RegisterType.HL => (ushort)((GetU8Register(RegisterType.H) << 8) | GetU8Register(RegisterType.L)),
                _ => throw new ArgumentException("Given type isn't a valid 16bit register. Try GetU8Register instead.")
            };
        }

        public void SetU8Register(RegisterType type, byte value)
        {
            switch (type)
            {
                case RegisterType.A: registers[0] = value; break;
                case RegisterType.B: registers[1] = value; break;
                case RegisterType.C: registers[2] = value; break;
                case RegisterType.D: registers[3] = value; break;
                case RegisterType.E: registers[4] = value; break;
                case RegisterType.F: registers[5] = value; break;
                case RegisterType.H: registers[6] = value; break;
                case RegisterType.L: registers[7] = value; break;
            }
        }

        public void SetU16Register(RegisterType type, ushort value)
        {
            switch (type)
            {
                case RegisterType.AF:
                    SetU8Register(RegisterType.A, (byte)((value & 0xFF00) >> 8));
                    SetU8Register(RegisterType.F, (byte)(value & 0xFF));
                    break;
                case RegisterType.BC:
                    SetU8Register(RegisterType.B, (byte)((value & 0xFF00) >> 8));
                    SetU8Register(RegisterType.C, (byte)(value & 0xFF));
                    break;
                case RegisterType.DE:
                    SetU8Register(RegisterType.D, (byte)((value & 0xFF00) >> 8));
                    SetU8Register(RegisterType.E, (byte)(value & 0xFF));
                    break;
                case RegisterType.HL:
                    SetU8Register(RegisterType.H, (byte)((value & 0xFF00) >> 8));
                    SetU8Register(RegisterType.L, (byte)(value & 0xFF));
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