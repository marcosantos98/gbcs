namespace GBCS.GB.Insts
{
    public class CPL : Instruction
    {
        public CPL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "CPL");
            _cpu.RegA = (byte)~_cpu.RegA;

            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag(true);

            return (true, 4);
        }
    }
}