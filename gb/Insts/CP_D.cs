namespace GBCS.GB.Insts
{
    public class CP_D : Instruction
    {
        public CP_D(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "CP D");
            _cpu.SetZeroFlag(_cpu.RegA == _cpu.RegD);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag((_cpu.RegA & 0xF) < (_cpu.RegD & 0xF));
            _cpu.SetCarryFlag(_cpu.RegA < _cpu.RegD);
            return (true, 4);
        }
    }
}