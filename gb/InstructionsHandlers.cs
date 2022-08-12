using GB.Types;

namespace GB
{

    public class InstructionsHandlers
    {
        public static IDictionary<InstructionType, Action<CPU>> handlers = new Dictionary<InstructionType, Action<CPU>>();

        static InstructionsHandlers()
        {
            handlers.Add(InstructionType.ADD, (cpu) =>
            {
                byte a = cpu.GetU8Register(cpu.inst.rOne);
                byte b = cpu.GetU8Register(cpu.inst.rTwo);
                (byte, bool) result = OverflowAdd(a, b);
                cpu.flags.zero = result.Item1 == 0;
                cpu.flags.substract = false;
                cpu.flags.carry = result.Item2;
                cpu.flags.halfCarry = (a & 0xF) + (b & 0xF) > 0xF;
                cpu.SetU8Register(RegisterType.A, result.Item1);
            });
        }

        private static (byte, bool) OverflowAdd(byte a, byte b)
        {
            bool overflow = false;
            if (a + b > 0xFF) overflow = true;
            return ((byte)(a + b), overflow);
        }
    }
}