namespace GBCS.GB.Insts
{
    public class LD_A_H : Instruction
    {
        public LD_A_H(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD A, H");
            _cpu.RegA = _cpu.RegH;
            return (true, 4);
        }
    }
}