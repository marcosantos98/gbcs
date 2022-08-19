namespace GBCS.GB.Insts
{
    public class POP_AF : Instruction
    {
        public POP_AF(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "POP AF");
            ushort spAddress = (ushort)(_cpu.Mem.ReadU16(_cpu.Sp) & 0xFFF0);
            _cpu.Sp += 2;
            _cpu.RegA = (byte)((spAddress >> 8) & 0xFF);
            _cpu.RegF = (byte)(spAddress & 0xFF);
            _cpu.Stack.LogLn("PC: {3:X4} POP AF: {0:X2}{1:X2} from SP: {2:X4}", _cpu.RegA, _cpu.RegF, _cpu.Sp - 2, _cpu.Pc);
            return (true, 12);
        }
    }
}