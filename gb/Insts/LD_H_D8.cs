namespace GBCS.GB.Insts
{
    public class LD_H_D8 : Instruction
    {
        public LD_H_D8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte val = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "LD H, $" + val.ToString("X"));
            _cpu.RegH = val;
            return (true, 8);
        }
    }
}