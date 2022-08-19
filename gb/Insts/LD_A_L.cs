namespace GBCS.GB.Insts
{
    public class LD_A_L : Instruction
    {
        public LD_A_L(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD A, L");
            _cpu.RegA = _cpu.RegL;
            return (true, 4);
        }
    }
}