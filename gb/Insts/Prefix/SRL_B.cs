namespace GBCS.GB.Insts.Prefix
{
    public class SRL_B : PrefixInstruction
    {
        public SRL_B(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte newValue = (byte)(_cpu.RegB >> 1);
            _cpu.SetZeroFlag(newValue == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag((_cpu.RegB & 0b1) > 0);
            _cpu.RegB = newValue;
            return (true, 8);
        }

        public override string Name()
        {
            return "SRL B";
        }
    }
}