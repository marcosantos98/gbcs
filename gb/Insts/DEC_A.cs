namespace GBCS.GB.Insts
{
    public class DEC_A : Instruction
    {
        public DEC_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "DEC A");
            _cpu.RegA--;

            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag(((_cpu.RegA + 1) & 0xF0) != (_cpu.RegA & 0xF0));

            return (true, 4);
        }
    }
}