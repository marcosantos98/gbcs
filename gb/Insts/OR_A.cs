namespace GBCS.GB.Insts
{
    public class OR_A : Instruction
    {
        public OR_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "OR A");
            _cpu.RegA |= _cpu.RegA;
            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag(false);
            return (true, 4);
        }
    }
}