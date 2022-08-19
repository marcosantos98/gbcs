namespace GBCS.GB.Insts
{
    public class DEC_E : Instruction
    {
        public DEC_E(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "DEC E");
            _cpu.RegE--;

            _cpu.SetZeroFlag(_cpu.RegE == 0);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag(((_cpu.RegE + 1) & 0xF0) != (_cpu.RegE & 0xF0));

            return (true, 4);
        }
    }
}