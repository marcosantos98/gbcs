namespace GBCS.GB.Insts.Prefix
{
    public class SWAP_A : PrefixInstruction
    {
        public SWAP_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte aLow = (byte)(_cpu.RegA & 0xF);
            byte aHi = (byte)((_cpu.RegA & 0xF0) >> 4);

            _cpu.RegA = (byte)((aLow << 4) | (aHi));

            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag(false);

            return (true, 8);
        }

        public override string Name()
        {
            return "SWAP A";
        }
    }
}