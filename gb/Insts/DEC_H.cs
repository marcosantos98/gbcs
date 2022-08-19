namespace GBCS.GB.Insts
{
    public class DEC_H : Instruction
    {
        public DEC_H(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "DEC H");
            _cpu.RegH--;

            _cpu.SetZeroFlag(_cpu.RegH == 0);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag(((_cpu.RegH + 1) & 0xF0) != (_cpu.RegH & 0xF0));

            return (true, 4);
        }
    }
}