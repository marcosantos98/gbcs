namespace GBCS.GB
{
    public class AddressDataHandlers
    {
        private static readonly IDictionary<AddressMode, Action<CPU>> Handlers = new Dictionary<AddressMode, Action<CPU>>();

        static AddressDataHandlers()
        {
            Handlers.Add(AddressMode.IMP, cpu => { });
            Handlers.Add(AddressMode.R, cpu => cpu.AddressData = cpu.GetRegister(cpu.Inst.RegOne));
            Handlers.Add(AddressMode.R_R, cpu => cpu.AddressData = cpu.GetRegister(cpu.Inst.RegTwo));
            Handlers.Add(AddressMode.D16, D16);
            Handlers.Add(AddressMode.R_D16, D16);
        }

        public static Action<CPU> Get(AddressMode mode)
        {
            return Handlers[mode];
        }

        private static void D16(CPU cpu)
        {
            byte lo = cpu.Mem.Read(cpu.Pc);
            //fixme 22/08/14: Cycles
            byte hi = cpu.Mem.Read((ushort)(cpu.Pc + 1));
            //fixme 22/08/14: Cycles
            cpu.AddressData = (ushort)(lo | (hi << 8));
            Console.WriteLine("{0:X2} {1:X2}, {2:X4}", lo, hi, cpu.AddressData);
            cpu.Pc += 2;
        }
    }
}