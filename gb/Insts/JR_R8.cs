namespace GBCS.GB.Insts
{
    public class JR_R8 : Instruction
    {
        public JR_R8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            sbyte rel = (sbyte)_cpu.Mem.Read(_cpu.Pc++);
            ushort jpAddress = (ushort)(_cpu.Pc + rel);
            Console.Write("{0,-14}", "JR $" + jpAddress.ToString("X"));
            _cpu.Pc = jpAddress;
            return (true, 12);
        }
    }
}