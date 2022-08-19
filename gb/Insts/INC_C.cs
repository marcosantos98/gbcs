namespace GBCS.GB.Insts
{
    public class INC_C : Instruction
    {
        public INC_C(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC C");
            byte oldValue = _cpu.RegC++;

            _cpu.SetZeroFlag(_cpu.RegC == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((oldValue & 0xF) == 0xF);

            return (true, 4);
        }
    }
}