namespace GBCS.GB.Insts
{
    public class PUSH_BC : Instruction
    {
        public PUSH_BC(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "PUSH BC");
            _cpu.Stack.LogLn("PC: {3:X4} PUSH BC: {0:X2}{1:X2} from SP: {2:X4}", _cpu.RegB, _cpu.RegC, _cpu.Sp, _cpu.Pc);
            _cpu.Sp--;
            _cpu.StackHolder[_cpu.Sp] = _cpu.RegB;
            _cpu.Mem.Write(_cpu.Sp, _cpu.RegB);
            _cpu.Sp--;
            _cpu.StackHolder[_cpu.Sp] = _cpu.RegC;
            _cpu.Mem.Write(_cpu.Sp, _cpu.RegC);
            return (true, 16);
        }
    }
}