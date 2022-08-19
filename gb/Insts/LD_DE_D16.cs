namespace GBCS.GB.Insts
{
    public class LD_DE_D16 : Instruction
    {
        public LD_DE_D16(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort memVal = _cpu.Mem.ReadU16(_cpu.Pc);
            Console.Write("{0,-14}", "LD DE, $" + memVal.ToString("X"));
            _cpu.Pc += 2;
            _cpu.RegD = (byte)((memVal & 0xFF00) >> 8);
            _cpu.RegE = (byte)(memVal & 0xFF);
            return (true, 12);
        }
    }
}