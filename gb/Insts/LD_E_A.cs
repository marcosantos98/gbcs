namespace GBCS.GB.Insts
{
    public class LD_E_A : Instruction
    {
        public LD_E_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD E, A");
            _cpu.RegE = _cpu.RegA;
            return (true, 4);
        }
    }
}