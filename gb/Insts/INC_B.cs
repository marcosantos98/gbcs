namespace GBCS.GB.Insts
{
    public class INC_B : Instruction
    {
        public INC_B(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC B");
            byte oldValue = _cpu.RegB++;

            _cpu.SetZeroFlag(_cpu.RegB == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((oldValue & 0xF) == 0xF);

            return (true, 4);
        }
    }
}