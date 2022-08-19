namespace GBCS.GB.Insts
{
    public class Noop : Instruction
    {
        public Noop(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "NOOP");
            return (true, 4);
        }
    }
}