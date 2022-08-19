namespace GBCS.GB.Insts
{
    public class RRA : Instruction
    {
        public RRA(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "RRA");
            byte carry = (byte)(_cpu.GetFlags().carry ? 1 : 0);
            byte val = (byte)((_cpu.RegA >> 1) | (carry << 7));

            _cpu.SetZeroFlag(val == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag((_cpu.RegA & 1) != 0);

            _cpu.RegA = val;

            return (true, 4);
        }
    }
}