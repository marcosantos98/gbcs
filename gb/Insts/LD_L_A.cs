namespace GBCS.GB.Insts
{
    public class LD_L_A : Instruction
    {
        public LD_L_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD L, A");
            _cpu.RegL = _cpu.RegA;
            return (true, 4);
        }
    }
}