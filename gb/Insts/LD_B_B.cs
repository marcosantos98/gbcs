namespace GBCS.GB.Insts
{
    public class LD_B_B : Instruction
    {
        public LD_B_B(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD B, B");
            _cpu.RegB = _cpu.RegB;
            return (true, 4);
        }
    }
}