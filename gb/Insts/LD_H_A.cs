namespace GBCS.GB.Insts
{
    public class LD_H_A : Instruction
    {
        public LD_H_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD H, A");
            _cpu.RegH = _cpu.RegA;
            return (true, 4);
        }
    }
}