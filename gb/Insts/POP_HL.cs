namespace GBCS.GB.Insts
{
    public class POP_HL : Instruction
    {
        public POP_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "POP HL");
            ushort spAddress = _cpu.Mem.ReadU16(_cpu.Sp);
            _cpu.Sp += 2;
            _cpu.RegH = (byte)((spAddress >> 8) & 0xFF);
            _cpu.RegL = (byte)(spAddress & 0xFF);
            _cpu.Stack.LogLn("PC: {3:X4} POP HL: {0:X2}{1:X2} from SP: {2:X4}", _cpu.RegH, _cpu.RegL, _cpu.Sp - 2, _cpu.Pc);
            return (true, 12);
        }
    }
}