namespace GBCS.GB.Insts
{
    public class DEC_L : Instruction
    {
        public DEC_L(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "DEC L");
            _cpu.RegL--;

            _cpu.SetZeroFlag(_cpu.RegL == 0);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag(((_cpu.RegL + 1) & 0xF0) != (_cpu.RegL & 0xF0));

            return (true, 4);
        }
    }
}