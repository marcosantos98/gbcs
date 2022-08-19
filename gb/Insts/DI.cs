namespace GBCS.GB.Insts
{
    public class DI : Instruction
    {
        public DI(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "DI");
            _cpu.InterruptsEnabled = false;
            return (true, 4);
        }
    }
}