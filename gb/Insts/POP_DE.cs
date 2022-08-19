namespace GBCS.GB.Insts
{
    public class POP_DE : Instruction
    {
        public POP_DE(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "POP DE");
            ushort spAddress = _cpu.Mem.ReadU16(_cpu.Sp);
            _cpu.Sp += 2;
            _cpu.RegD = (byte)((spAddress >> 8) & 0xFF);
            _cpu.RegE = (byte)(spAddress & 0xFF);
            _cpu.Stack.LogLn("PC: {3:X4} POP DE: {0:X2}{1:X2} from SP: {2:X4}", _cpu.RegD, _cpu.RegE, _cpu.Sp - 2, _cpu.Pc);
            return (true, 12);
        }
    }
}