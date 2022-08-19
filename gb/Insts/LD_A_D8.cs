namespace GBCS.GB.Insts
{
    public class LD_A_D8 : Instruction
    {
        public LD_A_D8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte val = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "LD A, $" + val.ToString("X"));
            _cpu.RegA = val;
            return (true, 8);
        }
    }
}