namespace GBCS.GB.Insts
{
    public class LD_A_D : Instruction
    {
        public LD_A_D(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD A, D");
            _cpu.RegA = _cpu.RegD;
            return (true, 4);
        }
    }
}