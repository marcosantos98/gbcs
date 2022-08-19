namespace GBCS.GB.Insts
{
    public class OR_C : Instruction
    {
        public OR_C(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "OR C");
            _cpu.RegA |= _cpu.RegC;
            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag(false);
            return (true, 4);
        }
    }
}