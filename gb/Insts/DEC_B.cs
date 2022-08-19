namespace GBCS.GB.Insts
{
    public class DEC_B : Instruction
    {
        public DEC_B(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "DEC B");
            _cpu.RegB--;

            _cpu.SetZeroFlag(_cpu.RegB == 0);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag(((_cpu.RegB + 1) & 0xF0) != (_cpu.RegB & 0xF0));

            return (true, 4);
        }
    }
}