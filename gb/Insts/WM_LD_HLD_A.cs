namespace GBCS.GB.Insts
{
    public class WM_LD_HLD_A : Instruction
    {
        public WM_LD_HLD_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD (HL-), A");
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            _cpu.Mem.Write(hl, _cpu.RegA);
            hl--;
            _cpu.RegH = (byte)((hl >> 8) & 0xFF);
            _cpu.RegL = (byte)(hl & 0xFF);
            return (true, 8);
        }
    }
}