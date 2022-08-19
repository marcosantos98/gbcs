namespace GBCS.GB.Insts
{
    public class LD_HL_SP_R8 : Instruction
    {
        public LD_HL_SP_R8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            sbyte address = (sbyte)_cpu.Mem.Read(_cpu.Pc++);
            Console.Write(" {0,-14}", "LD HL, SP+R8");

            ushort hl = (ushort)(_cpu.Sp + address);

            _cpu.RegH = (byte)((hl << 8) & 0xFF);
            _cpu.RegL = (byte)(hl & 0xFF);

            _cpu.SetZeroFlag(false);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((_cpu.Sp & 0xF) + (address & 0xF) > 0xF);
            _cpu.SetCarryFlag((_cpu.Sp & 0xFF) + (address & 0xFF) > 0xFF);

            return (true, 12);
        }
    }
}