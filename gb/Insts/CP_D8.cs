namespace GBCS.GB.Insts
{
    public class CP_D8 : Instruction
    {
        public CP_D8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte val = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "CP $" + val.ToString("X"));
            _cpu.SetZeroFlag(_cpu.RegA == val);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag((_cpu.RegA & 0xF) < (val & 0xF));
            _cpu.SetCarryFlag(_cpu.RegA < val);
            return (true, 8);
        }
    }
}