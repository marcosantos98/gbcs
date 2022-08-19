namespace GBCS.GB.Insts
{
    public class CP_C : Instruction
    {
        public CP_C(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "CP C");
            _cpu.SetZeroFlag(_cpu.RegA == _cpu.RegC);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag((_cpu.RegA & 0xF) < (_cpu.RegC & 0xF));
            _cpu.SetCarryFlag(_cpu.RegA < _cpu.RegC);
            return (true, 4);
        }
    }
}