namespace GBCS.GB.Insts
{
    public class INC_E : Instruction
    {
        public INC_E(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC E");
            byte oldValue = _cpu.RegE++;

            _cpu.SetZeroFlag(_cpu.RegE == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((oldValue & 0xF) == 0xF);

            return (true, 4);
        }
    }
}