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
            Handlers.Add(AddressMode.A8_R, cpu =>
            {
                cpu.AddressData = cpu.Mem.Read(cpu.Pc++);
                cpu.PcIsMemDest = true;
                //fixme 22/08/14: Cycles
            });
            Handlers.Add(AddressMode.D16, RD16_D16);
            Handlers.Add(AddressMode.R_D16, RD16_D16);
            Handlers.Add(AddressMode.A16_R, A16R_D16R);
            Handlers.Add(AddressMode.D16_R, A16R_D16R);
            Handlers.Add(AddressMode.R_D8, RD8_D8_RA8_HLSPR);
            Handlers.Add(AddressMode.D8, RD8_D8_RA8_HLSPR);
            Handlers.Add(AddressMode.R_A8, RD8_D8_RA8_HLSPR);
            Handlers.Add(AddressMode.HL_SPR, RD8_D8_RA8_HLSPR);
        }

        public static Action<CPU> Get(AddressMode mode)
        {
            return Handlers[mode];
        }

        private static void RD16_D16(CPU cpu)
        {
            byte lo = cpu.Mem.Read(cpu.Pc);
            //fixme 22/08/14: Cycles
            byte hi = cpu.Mem.Read((ushort)(cpu.Pc + 1));
            //fixme 22/08/14: Cycles
            cpu.AddressData = (ushort)(lo | (hi << 8));
            cpu.Pc += 2;
        }

        private static void A16R_D16R(CPU cpu)
        {
            byte lo = cpu.Mem.Read(cpu.Pc);
            //fixme 22/08/14: Cycles
            byte hi = cpu.Mem.Read((ushort)(cpu.Pc + 1));
            //fixme 22/08/14: Cycles
            cpu.MemDest = (ushort)(lo | (hi << 8));
            Logger.LogLn("\tLow 0x{0:X2}, Hi 0x{1:X2}, Val: 0x{2:X4}", lo, hi, cpu.MemDest);
            cpu.PcIsMemDest = true;
            cpu.Pc += 2;
            cpu.AddressData = cpu.GetRegister(cpu.Inst.RegTwo);
        }

        private static void RD8_D8_RA8_HLSPR(CPU cpu)
        {
            cpu.AddressData = cpu.Mem.Read(cpu.Pc++);
            //fixme 22/08/14: cycles
        }
    }
}