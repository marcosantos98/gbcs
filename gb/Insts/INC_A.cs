namespace GBCS.GB.Insts
{
    public class INC_A : Instruction
    {
        public INC_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC A");
            byte oldValue = _cpu.RegA++;

            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((oldValue & 0xF) == 0xF);

            return (true, 4);
        }
    }
}