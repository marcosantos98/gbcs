namespace GBCS.GB
{

    public class Instructions
    {

        private static readonly IDictionary<byte, Instruction> Insts = new Dictionary<byte, Instruction>();

        static Instructions()
        {
            Insts.Add(0x00, IBuilder.Type(InstructionType.NOP).Ret());
            Insts.Add(0x01, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D16).One(RegisterType.BC).Ret());
            Insts.Add(0x02, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.BC).Two(RegisterType.A).Ret());
            Insts.Add(0x03, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.BC).Ret());
            Insts.Add(0x04, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.B).Ret());
            Insts.Add(0x05, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.B).Ret());
            Insts.Add(0x06, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D8).One(RegisterType.B).Ret());
            Insts.Add(0x07, IBuilder.Type(InstructionType.RLCA).Ret());
            Insts.Add(0x08, IBuilder.Type(InstructionType.LD).Addr(AddressMode.A16_R).One(RegisterType.NONE).Two(RegisterType.SP).Ret());
            Insts.Add(0x09, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.HL).Two(RegisterType.BC).Ret());
            Insts.Add(0x0A, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.BC).Ret());
            Insts.Add(0x0B, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.BC).Ret());
            Insts.Add(0x0C, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.C).Ret());
            Insts.Add(0x0D, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.C).Ret());
            Insts.Add(0x0E, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D8).One(RegisterType.C).Ret());
            Insts.Add(0x0F, IBuilder.Type(InstructionType.RRCA).Ret());

            Insts.Add(0x10, IBuilder.Type(InstructionType.STOP).Ret());
            Insts.Add(0x11, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D16).One(RegisterType.DE).Ret());
            Insts.Add(0x12, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.DE).Two(RegisterType.A).Ret());
            Insts.Add(0x13, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.DE).Ret());
            Insts.Add(0x14, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.D).Ret());
            Insts.Add(0x15, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.D).Ret());
            Insts.Add(0x16, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D8).One(RegisterType.D).Ret());
            Insts.Add(0x17, IBuilder.Type(InstructionType.RLA).Ret());
            Insts.Add(0x18, IBuilder.Type(InstructionType.JR).Addr(AddressMode.D8).Ret());
            Insts.Add(0x19, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.HL).Two(RegisterType.DE).Ret());
            Insts.Add(0x1A, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.DE).Ret());
            Insts.Add(0x1B, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.DE).Ret());
            Insts.Add(0x1C, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.E).Ret());
            Insts.Add(0x1E, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D8).One(RegisterType.E).Ret());
            Insts.Add(0x1D, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.E).Ret());
            Insts.Add(0x1F, IBuilder.Type(InstructionType.RRA).Ret());

            Insts.Add(0x20, IBuilder.Type(InstructionType.JR).Addr(AddressMode.D8).Cond(ConditionType.NZ).Ret());
            Insts.Add(0x21, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D16).One(RegisterType.HL).Ret());
            Insts.Add(0x22, IBuilder.Type(InstructionType.LD).Addr(AddressMode.HLI_R).One(RegisterType.HL).Two(RegisterType.A).Ret());
            Insts.Add(0x23, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.HL).Ret());
            Insts.Add(0x24, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.H).Ret());
            Insts.Add(0x25, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.H).Ret());
            Insts.Add(0x26, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D8).One(RegisterType.H).Ret());
            Insts.Add(0x27, IBuilder.Type(InstructionType.DAA).Ret());
            Insts.Add(0x28, IBuilder.Type(InstructionType.JR).Addr(AddressMode.D8).Cond(ConditionType.Z).Ret());
            Insts.Add(0x29, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.HL).Two(RegisterType.HL).Ret());
            Insts.Add(0x2A, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_HLI).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0x2B, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.HL).Ret());
            Insts.Add(0x2C, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.L).Ret());
            Insts.Add(0x2D, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.L).Ret());
            Insts.Add(0x2E, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D8).One(RegisterType.L).Ret());
            Insts.Add(0x2F, IBuilder.Type(InstructionType.CPL).Ret());

            Insts.Add(0x30, IBuilder.Type(InstructionType.JR).Addr(AddressMode.D8).Cond(ConditionType.NC).Ret());
            Insts.Add(0x31, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D16).One(RegisterType.SP).Ret());
            Insts.Add(0x32, IBuilder.Type(InstructionType.LD).Addr(AddressMode.HLD_R).One(RegisterType.HL).Two(RegisterType.A).Ret());
            Insts.Add(0x33, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.SP).Ret());
            Insts.Add(0x34, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.HL).Ret());
            Insts.Add(0x35, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.MR).One(RegisterType.HL).Ret());
            Insts.Add(0x36, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_D8).One(RegisterType.HL).Ret());
            Insts.Add(0x37, IBuilder.Type(InstructionType.SCF).Ret());
            Insts.Add(0x38, IBuilder.Type(InstructionType.JR).Addr(AddressMode.D8).Cond(ConditionType.C).Ret());
            Insts.Add(0x39, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.HL).Two(RegisterType.SP).Ret());
            Insts.Add(0x3A, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_HLD).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0x3B, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.SP).Ret());
            Insts.Add(0x3C, IBuilder.Type(InstructionType.INC).Addr(AddressMode.R).One(RegisterType.A).Ret());
            Insts.Add(0x3E, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_D8).One(RegisterType.A).Ret());
            Insts.Add(0x3D, IBuilder.Type(InstructionType.DEC).Addr(AddressMode.R).One(RegisterType.A).Ret());
            Insts.Add(0x3F, IBuilder.Type(InstructionType.CCF).Ret());

            Insts.Add(0x40, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.B).Two(RegisterType.B).Ret());
            Insts.Add(0x41, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.B).Two(RegisterType.C).Ret());
            Insts.Add(0x42, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.B).Two(RegisterType.D).Ret());
            Insts.Add(0x43, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.B).Two(RegisterType.E).Ret());
            Insts.Add(0x44, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.B).Two(RegisterType.H).Ret());
            Insts.Add(0x45, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.B).Two(RegisterType.L).Ret());
            Insts.Add(0x46, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.B).Two(RegisterType.HL).Ret());
            Insts.Add(0x47, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.B).Two(RegisterType.A).Ret());
            Insts.Add(0x48, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.C).Two(RegisterType.B).Ret());
            Insts.Add(0x49, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.C).Two(RegisterType.C).Ret());
            Insts.Add(0x4A, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.C).Two(RegisterType.D).Ret());
            Insts.Add(0x4B, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.C).Two(RegisterType.E).Ret());
            Insts.Add(0x4C, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.C).Two(RegisterType.H).Ret());
            Insts.Add(0x4D, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.C).Two(RegisterType.L).Ret());
            Insts.Add(0x4E, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.C).Two(RegisterType.HL).Ret());
            Insts.Add(0x4F, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.C).Two(RegisterType.A).Ret());

            Insts.Add(0x50, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.D).Two(RegisterType.B).Ret());
            Insts.Add(0x51, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.D).Two(RegisterType.C).Ret());
            Insts.Add(0x52, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.D).Two(RegisterType.D).Ret());
            Insts.Add(0x53, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.D).Two(RegisterType.E).Ret());
            Insts.Add(0x54, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.D).Two(RegisterType.H).Ret());
            Insts.Add(0x55, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.D).Two(RegisterType.L).Ret());
            Insts.Add(0x56, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.D).Two(RegisterType.HL).Ret());
            Insts.Add(0x57, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.D).Two(RegisterType.A).Ret());
            Insts.Add(0x58, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.E).Two(RegisterType.B).Ret());
            Insts.Add(0x59, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.E).Two(RegisterType.C).Ret());
            Insts.Add(0x5A, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.E).Two(RegisterType.D).Ret());
            Insts.Add(0x5B, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.E).Two(RegisterType.E).Ret());
            Insts.Add(0x5C, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.E).Two(RegisterType.H).Ret());
            Insts.Add(0x5D, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.E).Two(RegisterType.L).Ret());
            Insts.Add(0x5E, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.E).Two(RegisterType.HL).Ret());
            Insts.Add(0x5F, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.E).Two(RegisterType.A).Ret());

            Insts.Add(0x60, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.H).Two(RegisterType.B).Ret());
            Insts.Add(0x61, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.H).Two(RegisterType.C).Ret());
            Insts.Add(0x62, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.H).Two(RegisterType.D).Ret());
            Insts.Add(0x63, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.H).Two(RegisterType.E).Ret());
            Insts.Add(0x64, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.H).Two(RegisterType.H).Ret());
            Insts.Add(0x65, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.H).Two(RegisterType.L).Ret());
            Insts.Add(0x66, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.H).Two(RegisterType.HL).Ret());
            Insts.Add(0x67, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.H).Two(RegisterType.A).Ret());
            Insts.Add(0x68, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.L).Two(RegisterType.B).Ret());
            Insts.Add(0x69, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.L).Two(RegisterType.C).Ret());
            Insts.Add(0x6A, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.L).Two(RegisterType.D).Ret());
            Insts.Add(0x6B, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.L).Two(RegisterType.E).Ret());
            Insts.Add(0x6C, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.L).Two(RegisterType.H).Ret());
            Insts.Add(0x6D, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.L).Two(RegisterType.L).Ret());
            Insts.Add(0x6E, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.L).Two(RegisterType.HL).Ret());
            Insts.Add(0x6F, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.L).Two(RegisterType.A).Ret());

            Insts.Add(0x70, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.HL).Two(RegisterType.B).Ret());
            Insts.Add(0x71, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.HL).Two(RegisterType.C).Ret());
            Insts.Add(0x72, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.HL).Two(RegisterType.D).Ret());
            Insts.Add(0x73, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.HL).Two(RegisterType.E).Ret());
            Insts.Add(0x74, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.HL).Two(RegisterType.H).Ret());
            Insts.Add(0x75, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.HL).Two(RegisterType.L).Ret());
            Insts.Add(0x76, IBuilder.Type(InstructionType.HALT).Ret());
            Insts.Add(0x77, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.HL).Two(RegisterType.A).Ret());
            Insts.Add(0x78, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.B).Ret());
            Insts.Add(0x79, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0x7A, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.D).Ret());
            Insts.Add(0x7B, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.E).Ret());
            Insts.Add(0x7C, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.H).Ret());
            Insts.Add(0x7D, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.L).Ret());
            Insts.Add(0x7E, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0x7F, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.A).Ret());

            Insts.Add(0x80, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.B).Ret());
            Insts.Add(0x81, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0x82, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.D).Ret());
            Insts.Add(0x83, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.E).Ret());
            Insts.Add(0x84, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.H).Ret());
            Insts.Add(0x85, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.L).Ret());
            Insts.Add(0x86, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0x87, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.A).Ret());
            Insts.Add(0x88, IBuilder.Type(InstructionType.ADC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.B).Ret());
            Insts.Add(0x89, IBuilder.Type(InstructionType.ADC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0x8A, IBuilder.Type(InstructionType.ADC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.D).Ret());
            Insts.Add(0x8B, IBuilder.Type(InstructionType.ADC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.E).Ret());
            Insts.Add(0x8C, IBuilder.Type(InstructionType.ADC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.H).Ret());
            Insts.Add(0x8D, IBuilder.Type(InstructionType.ADC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.L).Ret());
            Insts.Add(0x8E, IBuilder.Type(InstructionType.ADC).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0x8F, IBuilder.Type(InstructionType.ADC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.A).Ret());

            Insts.Add(0x90, IBuilder.Type(InstructionType.SUB).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.B).Ret());
            Insts.Add(0x91, IBuilder.Type(InstructionType.SUB).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0x92, IBuilder.Type(InstructionType.SUB).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.D).Ret());
            Insts.Add(0x93, IBuilder.Type(InstructionType.SUB).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.E).Ret());
            Insts.Add(0x94, IBuilder.Type(InstructionType.SUB).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.H).Ret());
            Insts.Add(0x95, IBuilder.Type(InstructionType.SUB).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.L).Ret());
            Insts.Add(0x96, IBuilder.Type(InstructionType.SUB).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0x97, IBuilder.Type(InstructionType.SUB).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.A).Ret());
            Insts.Add(0x98, IBuilder.Type(InstructionType.SBC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.B).Ret());
            Insts.Add(0x99, IBuilder.Type(InstructionType.SBC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0x9A, IBuilder.Type(InstructionType.SBC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.D).Ret());
            Insts.Add(0x9B, IBuilder.Type(InstructionType.SBC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.E).Ret());
            Insts.Add(0x9C, IBuilder.Type(InstructionType.SBC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.H).Ret());
            Insts.Add(0x9D, IBuilder.Type(InstructionType.SBC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.L).Ret());
            Insts.Add(0x9E, IBuilder.Type(InstructionType.SBC).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0x9F, IBuilder.Type(InstructionType.SBC).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.A).Ret());

            Insts.Add(0xA0, IBuilder.Type(InstructionType.AND).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.B).Ret());
            Insts.Add(0xA1, IBuilder.Type(InstructionType.AND).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0xA2, IBuilder.Type(InstructionType.AND).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.D).Ret());
            Insts.Add(0xA3, IBuilder.Type(InstructionType.AND).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.E).Ret());
            Insts.Add(0xA4, IBuilder.Type(InstructionType.AND).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.H).Ret());
            Insts.Add(0xA5, IBuilder.Type(InstructionType.AND).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.L).Ret());
            Insts.Add(0xA6, IBuilder.Type(InstructionType.AND).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0xA7, IBuilder.Type(InstructionType.AND).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.A).Ret());
            Insts.Add(0xA8, IBuilder.Type(InstructionType.XOR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.B).Ret());
            Insts.Add(0xA9, IBuilder.Type(InstructionType.XOR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0xAA, IBuilder.Type(InstructionType.XOR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.D).Ret());
            Insts.Add(0xAB, IBuilder.Type(InstructionType.XOR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.E).Ret());
            Insts.Add(0xAC, IBuilder.Type(InstructionType.XOR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.H).Ret());
            Insts.Add(0xAD, IBuilder.Type(InstructionType.XOR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.L).Ret());
            Insts.Add(0xAE, IBuilder.Type(InstructionType.XOR).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0xAF, IBuilder.Type(InstructionType.XOR).Addr(AddressMode.R).One(RegisterType.A).Ret());

            Insts.Add(0xB0, IBuilder.Type(InstructionType.OR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.B).Ret());
            Insts.Add(0xB1, IBuilder.Type(InstructionType.OR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0xB2, IBuilder.Type(InstructionType.OR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.D).Ret());
            Insts.Add(0xB3, IBuilder.Type(InstructionType.OR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.E).Ret());
            Insts.Add(0xB4, IBuilder.Type(InstructionType.OR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.H).Ret());
            Insts.Add(0xB5, IBuilder.Type(InstructionType.OR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.L).Ret());
            Insts.Add(0xB6, IBuilder.Type(InstructionType.OR).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0xB7, IBuilder.Type(InstructionType.OR).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.A).Ret());
            Insts.Add(0xB8, IBuilder.Type(InstructionType.CP).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.B).Ret());
            Insts.Add(0xB9, IBuilder.Type(InstructionType.CP).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0xBA, IBuilder.Type(InstructionType.CP).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.D).Ret());
            Insts.Add(0xBB, IBuilder.Type(InstructionType.CP).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.E).Ret());
            Insts.Add(0xBC, IBuilder.Type(InstructionType.CP).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.H).Ret());
            Insts.Add(0xBD, IBuilder.Type(InstructionType.CP).Addr(AddressMode.R_R).One(RegisterType.A).Two(RegisterType.L).Ret());
            Insts.Add(0xBE, IBuilder.Type(InstructionType.CP).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.HL).Ret());
            Insts.Add(0xBF, IBuilder.Type(InstructionType.CP).Addr(AddressMode.R).One(RegisterType.A).Ret());

            Insts.Add(0xC0, IBuilder.Type(InstructionType.RET).Cond(ConditionType.NZ).Ret());
            Insts.Add(0xC1, IBuilder.Type(InstructionType.POP).One(RegisterType.BC).Ret());
            Insts.Add(0xC2, IBuilder.Type(InstructionType.JP).Addr(AddressMode.D16).Cond(ConditionType.NZ).Ret());
            Insts.Add(0xC3, IBuilder.Type(InstructionType.JP).Addr(AddressMode.D16).Ret());
            Insts.Add(0xC4, IBuilder.Type(InstructionType.CALL).Addr(AddressMode.D16).Cond(ConditionType.NZ).Ret());
            Insts.Add(0xC5, IBuilder.Type(InstructionType.PUSH).One(RegisterType.BC).Ret());
            Insts.Add(0xC6, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_D8).One(RegisterType.A).Ret());
            Insts.Add(0xC7, IBuilder.Type(InstructionType.RST).Param(0x00).Ret());
            Insts.Add(0xC8, IBuilder.Type(InstructionType.RET).Cond(ConditionType.Z).Ret());
            Insts.Add(0xC9, IBuilder.Type(InstructionType.RET).Ret());
            Insts.Add(0xCA, IBuilder.Type(InstructionType.JP).Addr(AddressMode.D16).Cond(ConditionType.Z).Ret());
            Insts.Add(0xCC, IBuilder.Type(InstructionType.CALL).Addr(AddressMode.D16).Cond(ConditionType.Z).Ret());
            Insts.Add(0xCB, IBuilder.Type(InstructionType.CB).Addr(AddressMode.D8).Ret());
            Insts.Add(0xCD, IBuilder.Type(InstructionType.CALL).Addr(AddressMode.D16).Ret());
            Insts.Add(0xCE, IBuilder.Type(InstructionType.ADC).Addr(AddressMode.R_D8).One(RegisterType.A).Ret());
            Insts.Add(0xCF, IBuilder.Type(InstructionType.RST).Param(0x08).Ret());

            Insts.Add(0xD0, IBuilder.Type(InstructionType.RET).Cond(ConditionType.NC).Ret());
            Insts.Add(0xD1, IBuilder.Type(InstructionType.POP).One(RegisterType.DE).Ret());
            Insts.Add(0xD2, IBuilder.Type(InstructionType.JP).Addr(AddressMode.D16).Cond(ConditionType.NC).Ret());
            Insts.Add(0xD4, IBuilder.Type(InstructionType.CALL).Addr(AddressMode.D16).Cond(ConditionType.NC).Ret());
            Insts.Add(0xD5, IBuilder.Type(InstructionType.PUSH).One(RegisterType.DE).Ret());
            Insts.Add(0xD6, IBuilder.Type(InstructionType.SUB).Addr(AddressMode.R_D8).Ret());
            Insts.Add(0xD7, IBuilder.Type(InstructionType.RST).Param(0x10).Ret());
            Insts.Add(0xD8, IBuilder.Type(InstructionType.RET).Cond(ConditionType.C).Ret());
            Insts.Add(0xD9, IBuilder.Type(InstructionType.RETI).Ret());
            Insts.Add(0xDA, IBuilder.Type(InstructionType.JP).Addr(AddressMode.D16).Cond(ConditionType.C).Ret());
            Insts.Add(0xDC, IBuilder.Type(InstructionType.CALL).Addr(AddressMode.D16).Cond(ConditionType.C).Ret());
            Insts.Add(0xDE, IBuilder.Type(InstructionType.SBC).Addr(AddressMode.R_D8).One(RegisterType.A).Ret());
            Insts.Add(0xDF, IBuilder.Type(InstructionType.RST).Param(0x18).Ret());

            Insts.Add(0xE0, IBuilder.Type(InstructionType.LDH).Addr(AddressMode.A8_R).One(RegisterType.NONE).Two(RegisterType.A).Ret());
            Insts.Add(0xE1, IBuilder.Type(InstructionType.POP).One(RegisterType.HL).Ret());
            Insts.Add(0xE2, IBuilder.Type(InstructionType.LD).Addr(AddressMode.MR_R).One(RegisterType.C).Two(RegisterType.A).Ret());
            Insts.Add(0xE5, IBuilder.Type(InstructionType.PUSH).One(RegisterType.HL).Ret());
            Insts.Add(0xE6, IBuilder.Type(InstructionType.AND).Addr(AddressMode.D8).Ret());
            Insts.Add(0xE7, IBuilder.Type(InstructionType.RST).Param(0x20).Ret());
            Insts.Add(0xE8, IBuilder.Type(InstructionType.ADD).Addr(AddressMode.R_D8).One(RegisterType.SP).Ret());
            Insts.Add(0xE9, IBuilder.Type(InstructionType.JP).Addr(AddressMode.MR).One(RegisterType.HL).Ret());
            Insts.Add(0xEA, IBuilder.Type(InstructionType.LD).Addr(AddressMode.A16_R).One(RegisterType.NONE).Two(RegisterType.A).Ret());
            Insts.Add(0xEE, IBuilder.Type(InstructionType.XOR).Addr(AddressMode.D8).Ret());
            Insts.Add(0xEF, IBuilder.Type(InstructionType.RST).Param(0x28).Ret());

            Insts.Add(0xF0, IBuilder.Type(InstructionType.LDH).Addr(AddressMode.R_A8).One(RegisterType.A).Ret());
            Insts.Add(0xF2, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_MR).One(RegisterType.A).Two(RegisterType.C).Ret());
            Insts.Add(0xF1, IBuilder.Type(InstructionType.POP).One(RegisterType.AF).Ret());
            Insts.Add(0xF3, IBuilder.Type(InstructionType.DI).Ret());
            Insts.Add(0xF5, IBuilder.Type(InstructionType.PUSH).One(RegisterType.AF).Ret());
            Insts.Add(0xF6, IBuilder.Type(InstructionType.OR).Addr(AddressMode.D8).Ret());
            Insts.Add(0xF8, IBuilder.Type(InstructionType.LD).Addr(AddressMode.HL_SPR).One(RegisterType.HL).Two(RegisterType.SP).Ret());
            Insts.Add(0xF9, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_R).One(RegisterType.SP).Two(RegisterType.HL).Ret());
            Insts.Add(0xFA, IBuilder.Type(InstructionType.LD).Addr(AddressMode.R_A16).One(RegisterType.A).Ret());
            Insts.Add(0xFB, IBuilder.Type(InstructionType.EI).Ret());
            Insts.Add(0xFE, IBuilder.Type(InstructionType.CP).Addr(AddressMode.D8).Ret());
            Insts.Add(0xFF, IBuilder.Type(InstructionType.RST).Param(0x38).Ret());
        }

        public static Instruction Get(byte opcode)
        {
            return Insts[opcode];
        }
    }

}