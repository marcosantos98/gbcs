namespace GBCS.GB.Insts
{
    public class JR_NZ_R8 : Instruction
    {
        public JR_NZ_R8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            if (!_cpu.GetFlags().zero)
            {
                sbyte address = (sbyte)_cpu.Mem.Read(_cpu.Pc++);

                _cpu.Pc = (ushort)(_cpu.Pc + address);

                Console.Write("{0,-14}", "JR NZ, $" + _cpu.Pc.ToString("X"));
                return (true, 12);
            }

            _cpu.Pc++;
            Console.Write("{0,-14}", "JR $" + _cpu.Pc.ToString("X"));
            return (true, 8);
        }
    }
}