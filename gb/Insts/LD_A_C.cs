namespace GBCS.GB.Insts
{
    public class LD_A_C : Instruction
    {
        public LD_A_C(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD A, C");
            _cpu.RegA = _cpu.RegC;
            return (true, 4);
        }
    }
}