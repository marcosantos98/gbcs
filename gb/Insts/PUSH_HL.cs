namespace GBCS.GB.Insts
{
    public class PUSH_HL : Instruction
    {
        public PUSH_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "PUSH HL");
            _cpu.Stack.LogLn("PC: {3:X4} PUSH HL: {0:X2}{1:X2} from SP: {2:X4}", _cpu.RegH, _cpu.RegL, _cpu.Sp, _cpu.Pc);
            _cpu.Sp--;
            _cpu.StackHolder[_cpu.Sp] = _cpu.RegH;
            _cpu.Mem.Write(_cpu.Sp, _cpu.RegH);
            _cpu.Sp--;
            _cpu.Mem.Write(_cpu.Sp, _cpu.RegL);
            _cpu.StackHolder[_cpu.Sp] = _cpu.RegL;
            return (true, 16);
        }
    }
}