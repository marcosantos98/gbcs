namespace GBCS.GB.Insts
{
    public class EI : Instruction
    {
        public EI(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "EI");
            _cpu.InterruptsEnabled = true;
            return (true, 4);
        }
    }
}