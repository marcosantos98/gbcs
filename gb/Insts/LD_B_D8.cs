namespace GBCS.GB.Insts
{
    public class LD_B_D8 : Instruction
    {
        public LD_B_D8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte val = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "LD B, $" + val.ToString("X"));
            _cpu.RegB = val;
            return (true, 8);
        }
    }
}