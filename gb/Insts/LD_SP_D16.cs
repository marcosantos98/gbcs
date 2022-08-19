namespace GBCS.GB.Insts
{
    public class LD_SP_D16 : Instruction
    {
        public LD_SP_D16(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort memVal = _cpu.Mem.ReadU16(_cpu.Pc);
            Console.Write("{0,-14}", "LD SP, $" + memVal.ToString("X"));
            _cpu.Pc += 2;
            _cpu.Sp = memVal;
            return (true, 12);
        }
    }
}