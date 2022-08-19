namespace GBCS.GB.Insts.Prefix
{
    public class RR_D : PrefixInstruction
    {
        public RR_D(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte carry = (byte)(_cpu.GetFlags().carry ? 1 : 0);
            byte val = (byte)((_cpu.RegD >> 1) | (carry << 7));

            _cpu.SetZeroFlag(val == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag((_cpu.RegD & 1) != 0);

            _cpu.RegD = val;

            return (true, 8);
        }

        public override string Name()
        {
            return "RR D";
        }
    }
}