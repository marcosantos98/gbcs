namespace GBCS.GB.Insts
{
    public class DAA : Instruction
    {
        public DAA(CPU cpu) : base(cpu)
        {
        }

        //https://github.com/rockytriton/LLD_gbemu/blob/e6be3433526a96401f7d42b653b37ab6a955415d/part16/lib/cpu_proc.c#L200
        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "DAA");

            byte u = 0;
            bool setCarry = false;

            if (_cpu.GetFlags().half || (!_cpu.GetFlags().subs && (_cpu.RegA & 0xF) > 9))
            {
                u = 6;
            }

            if (_cpu.GetFlags().carry || (!_cpu.GetFlags().subs && _cpu.RegA > 0x99))
            {
                u |= 0x60;
                setCarry = true;
            }

            _cpu.RegA += (byte)(_cpu.GetFlags().subs ? -u : u);

            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag(setCarry);

            return (true, 4);
        }
    }
}