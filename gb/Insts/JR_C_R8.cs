namespace GBCS.GB.Insts
{
    public class JR_C_R8 : Instruction
    {
        public JR_C_R8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            if (_cpu.GetFlags().carry)
            {
                ushort jpAddress = (ushort)(_cpu.Pc + (sbyte)_cpu.Mem.Read(_cpu.Pc));
                Console.Write("{0,-14}", "JR C, $" + jpAddress.ToString("X"));
                _cpu.Pc = (ushort)(jpAddress + 1);
                return (true, 12);
            }

            _cpu.Pc++;
            Console.Write("{0,-14}", "JR $" + _cpu.Pc.ToString("X"));
            return (true, 8);
        }
    }
}