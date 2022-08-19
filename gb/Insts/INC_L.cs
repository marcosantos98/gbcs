namespace GBCS.GB.Insts
{
    public class INC_L : Instruction
    {
        public INC_L(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC L");
            byte oldValue = _cpu.RegL++;

            _cpu.SetZeroFlag(_cpu.RegL == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((oldValue & 0xF) == 0xF);

            return (true, 4);
        }
    }
}