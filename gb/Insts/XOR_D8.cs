namespace GBCS.GB.Insts
{
    public class XOR_D8 : Instruction
    {
        public XOR_D8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte val = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "XOR $" + val.ToString("X"));
            _cpu.RegA ^= val;
            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag(false);
            return (true, 8);
        }
    }
}