namespace GBCS.GB.Insts
{
    public class DEC_C : Instruction
    {
        public DEC_C(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "DEC C");
            _cpu.RegC--;

            _cpu.SetZeroFlag(_cpu.RegC == 0);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag(((_cpu.RegC + 1) & 0xF0) != (_cpu.RegC & 0xF0));

            return (true, 4);
        }
    }
}