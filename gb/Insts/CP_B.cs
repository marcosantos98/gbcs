namespace GBCS.GB.Insts
{
    public class CP_B : Instruction
    {
        public CP_B(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "CP B");
            _cpu.SetZeroFlag(_cpu.RegA == _cpu.RegB);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag((_cpu.RegA & 0xF) < (_cpu.RegB & 0xF));
            _cpu.SetCarryFlag(_cpu.RegA < _cpu.RegB);
            return (true, 4);
        }
    }
}