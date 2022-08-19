namespace GBCS.GB.Insts
{
    public class INC_H : Instruction
    {
        public INC_H(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC H");
            byte oldValue = _cpu.RegH++;

            _cpu.SetZeroFlag(_cpu.RegH == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((oldValue & 0xF) == 0xF);

            return (true, 4);
        }
    }
}