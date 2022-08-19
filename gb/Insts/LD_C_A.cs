namespace GBCS.GB.Insts
{
    public class LD_C_A : Instruction
    {
        public LD_C_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD C, A");
            _cpu.RegC = _cpu.RegA;
            return (true, 4);
        }
    }
}