namespace GBCS.GB.Insts
{
    public class LD_A_E : Instruction
    {
        public LD_A_E(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD A, E");
            _cpu.RegA = _cpu.RegE;
            return (true, 4);
        }
    }
}