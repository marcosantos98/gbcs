namespace GBCS.GB.Insts
{
    public class CALL_A16 : Instruction
    {
        public CALL_A16(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort jpAddress = _cpu.Mem.ReadU16(_cpu.Pc);
            _cpu.Pc += 2;
            Console.Write("{0,-14}", "CALL $" + jpAddress.ToString("X"));
            _cpu.Sp--;
            _cpu.Mem.Write(_cpu.Sp, (byte)((_cpu.Pc >> 8) & 0xFF));
            _cpu.Sp--;
            _cpu.Mem.Write(_cpu.Sp, (byte)(_cpu.Pc & 0xFF));
            _cpu.Pc = jpAddress;
            return (true, 24);
        }
    }
}