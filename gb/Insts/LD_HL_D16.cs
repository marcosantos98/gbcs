namespace GBCS.GB.Insts
{
    public class LD_HL_D16 : Instruction
    {
        public LD_HL_D16(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort memVal = _cpu.Mem.ReadU16(_cpu.Pc);
            Console.Write("{0,-14}", "LD HL, $" + memVal.ToString("X"));
            _cpu.Pc += 2;
            _cpu.RegH = (byte)((memVal & 0xFF00) >> 8);
            _cpu.RegL = (byte)(memVal & 0xFF);
            return (true, 12);
        }
    }
}