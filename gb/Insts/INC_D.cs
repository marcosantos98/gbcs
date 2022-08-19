namespace GBCS.GB.Insts
{
    public class INC_D : Instruction
    {
        public INC_D(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC D");
            byte oldValue = _cpu.RegD++;

            _cpu.SetZeroFlag(_cpu.RegD == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((oldValue & 0xF) == 0xF);

            return (true, 4);
        }
    }
}