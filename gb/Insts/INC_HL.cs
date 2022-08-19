namespace GBCS.GB.Insts
{
    public class INC_HL : Instruction
    {
        public INC_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC HL");

            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            hl++;

            _cpu.RegH = (byte)((hl >> 8) & 0xFF);
            _cpu.RegL = (byte)(hl & 0xFF);

            return (true, 8);
        }
    }
}