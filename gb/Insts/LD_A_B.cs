namespace GBCS.GB.Insts
{
    public class LD_A_B : Instruction
    {
        public LD_A_B(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD A, B");
            _cpu.RegA = _cpu.RegB;
            return (true, 4);
        }
    }
}