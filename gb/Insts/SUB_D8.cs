namespace GBCS.GB.Insts
{
    public class SUB_D8 : Instruction
    {
        public SUB_D8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte val = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "SUB $" + val.ToString("X"));
            byte value = (byte)(_cpu.RegA - val);
            _cpu.SetZeroFlag(value == 0);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag((_cpu.RegA & 0xF) < (val & 0xF));
            _cpu.SetCarryFlag(_cpu.RegA < val);
            _cpu.RegA = value;
            return (true, 8);
        }
    }
}