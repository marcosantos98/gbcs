namespace GBCS.GB.Insts
{
    public class AND_D8 : Instruction
    {
        public AND_D8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte val = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "AND $" + val.ToString("X"));
            _cpu.RegA &= val;
            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(true);
            _cpu.SetCarryFlag(false);
            return (true, 8);
        }
    }
}