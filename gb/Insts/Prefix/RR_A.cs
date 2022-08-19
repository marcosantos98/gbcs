namespace GBCS.GB.Insts.Prefix
{
    public class RR_A : PrefixInstruction
    {
        public RR_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte carry = (byte)(_cpu.GetFlags().carry ? 1 : 0);
            byte val = (byte)((_cpu.RegA >> 1) | (carry << 7));

            _cpu.SetZeroFlag(val == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag((_cpu.RegA & 1) != 0);

            _cpu.RegA = val;

            return (true, 8);
        }

        public override string Name()
        {
            return "RR A";
        }
    }
}