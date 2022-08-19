namespace GBCS.GB.Insts
{
    public class WM_LD_HL_A : Instruction
    {
        public WM_LD_HL_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort address = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            Console.Write("{0,-14}", "LD ($" + address.ToString("X") + "), A");
            _cpu.Mem.Write(address, _cpu.RegA);
            return (true, 8);
        }
    }
}