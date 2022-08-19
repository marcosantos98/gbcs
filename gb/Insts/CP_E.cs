namespace GBCS.GB.Insts
{
    public class CP_E : Instruction
    {
        public CP_E(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "CP E");
            _cpu.SetZeroFlag(_cpu.RegA == _cpu.RegE);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag((_cpu.RegA & 0xF) < (_cpu.RegE & 0xF));
            _cpu.SetCarryFlag(_cpu.RegA < _cpu.RegE);
            return (true, 4);
        }
    }
}