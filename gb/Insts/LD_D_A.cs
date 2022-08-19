namespace GBCS.GB.Insts
{
    public class LD_D_A : Instruction
    {
        public LD_D_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD D, A");
            _cpu.RegD = _cpu.RegA;
            return (true, 4);
        }
    }
}