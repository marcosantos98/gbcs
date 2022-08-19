namespace GBCS.GB.Insts
{
    public class LD_B_A : Instruction
    {
        public LD_B_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD B, A");
            _cpu.RegB = _cpu.RegA;
            return (true, 4);
        }
    }
}