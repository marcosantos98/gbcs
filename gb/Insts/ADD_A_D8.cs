namespace GBCS.GB.Insts
{
    public class ADD_A_D8 : Instruction
    {
        public ADD_A_D8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte val = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "ADD $" + val.ToString("X"));
            _cpu.RegA += val;
            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((_cpu.RegA & 0xF) + (val & 0xF) > 0xF);
            _cpu.SetCarryFlag(val >= 0xFF);
            return (true, 8);
        }
    }
}