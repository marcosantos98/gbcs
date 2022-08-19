namespace GBCS.GB.Insts
{
    public class SCF : Instruction
    {
        public SCF(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "SCF");
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag(true);

            return (true, 4);
        }
    }
}