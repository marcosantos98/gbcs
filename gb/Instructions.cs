using GB.Types;

namespace GB
{

    public class Instructions
    {

        public static IDictionary<byte, Instruction> instructions = new Dictionary<byte, Instruction>();

        static Instructions()
        {
            instructions.Add(0x00, IBuilder.type(InstructionType.NOP).ret());
            instructions.Add(0x01, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D16).one(RegisterType.BC).ret());
            instructions.Add(0x02, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.BC).two(RegisterType.A).ret());
            instructions.Add(0x03, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.BC).ret());
            instructions.Add(0x04, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.B).ret());
            instructions.Add(0x05, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.B).ret());
            instructions.Add(0x06, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D8).one(RegisterType.B).ret());
            instructions.Add(0x07, IBuilder.type(InstructionType.RLCA).ret());
            instructions.Add(0x08, IBuilder.type(InstructionType.LD).addr(AddressMode.A16_R).one(RegisterType.NONE).two(RegisterType.SP).ret());
            instructions.Add(0x09, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.HL).two(RegisterType.BC).ret());
            instructions.Add(0x0A, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.BC).ret());
            instructions.Add(0x0B, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.BC).ret());
            instructions.Add(0x0C, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.C).ret());
            instructions.Add(0x0D, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.C).ret());
            instructions.Add(0x0E, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D8).one(RegisterType.C).ret());
            instructions.Add(0x0F, IBuilder.type(InstructionType.RRCA).ret());

            instructions.Add(0x10, IBuilder.type(InstructionType.STOP).ret());
            instructions.Add(0x11, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D16).one(RegisterType.DE).ret());
            instructions.Add(0x12, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.DE).two(RegisterType.A).ret());
            instructions.Add(0x13, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.DE).ret());
            instructions.Add(0x14, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.D).ret());
            instructions.Add(0x15, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.D).ret());
            instructions.Add(0x16, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D8).one(RegisterType.D).ret());
            instructions.Add(0x17, IBuilder.type(InstructionType.RLA).ret());
            instructions.Add(0x18, IBuilder.type(InstructionType.JR).addr(AddressMode.D8).ret());
            instructions.Add(0x19, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.HL).two(RegisterType.DE).ret());
            instructions.Add(0x1A, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.DE).ret());
            instructions.Add(0x1B, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.DE).ret());
            instructions.Add(0x1C, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.E).ret());
            instructions.Add(0x1E, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D8).one(RegisterType.E).ret());
            instructions.Add(0x1D, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.E).ret());
            instructions.Add(0x1F, IBuilder.type(InstructionType.RRA).ret());

            instructions.Add(0x20, IBuilder.type(InstructionType.JR).addr(AddressMode.D8).cond(ConditionType.NZ).ret());
            instructions.Add(0x21, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D16).one(RegisterType.HL).ret());
            instructions.Add(0x22, IBuilder.type(InstructionType.LD).addr(AddressMode.HLI_R).one(RegisterType.HL).two(RegisterType.A).ret());
            instructions.Add(0x23, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.HL).ret());
            instructions.Add(0x24, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.H).ret());
            instructions.Add(0x25, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.H).ret());
            instructions.Add(0x26, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D8).one(RegisterType.H).ret());
            instructions.Add(0x27, IBuilder.type(InstructionType.DAA).ret());
            instructions.Add(0x28, IBuilder.type(InstructionType.JR).addr(AddressMode.D8).cond(ConditionType.Z).ret());
            instructions.Add(0x29, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.HL).two(RegisterType.HL).ret());
            instructions.Add(0x2A, IBuilder.type(InstructionType.LD).addr(AddressMode.R_HLI).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0x2B, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.HL).ret());
            instructions.Add(0x2C, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.L).ret());
            instructions.Add(0x2D, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.L).ret());
            instructions.Add(0x2E, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D8).one(RegisterType.L).ret());
            instructions.Add(0x2F, IBuilder.type(InstructionType.CPL).ret());

            instructions.Add(0x30, IBuilder.type(InstructionType.JR).addr(AddressMode.D8).cond(ConditionType.NC).ret());
            instructions.Add(0x31, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D16).one(RegisterType.SP).ret());
            instructions.Add(0x32, IBuilder.type(InstructionType.LD).addr(AddressMode.HLD_R).one(RegisterType.HL).two(RegisterType.A).ret());
            instructions.Add(0x33, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.SP).ret());
            instructions.Add(0x34, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.HL).ret());
            instructions.Add(0x35, IBuilder.type(InstructionType.DEC).addr(AddressMode.MR).one(RegisterType.HL).ret());
            instructions.Add(0x36, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_D8).one(RegisterType.HL).ret());
            instructions.Add(0x37, IBuilder.type(InstructionType.SCF).ret());
            instructions.Add(0x38, IBuilder.type(InstructionType.JR).addr(AddressMode.D8).cond(ConditionType.C).ret());
            instructions.Add(0x39, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.HL).two(RegisterType.SP).ret());
            instructions.Add(0x3A, IBuilder.type(InstructionType.LD).addr(AddressMode.R_HLD).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0x3B, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.SP).ret());
            instructions.Add(0x3C, IBuilder.type(InstructionType.INC).addr(AddressMode.R).one(RegisterType.A).ret());
            instructions.Add(0x3E, IBuilder.type(InstructionType.LD).addr(AddressMode.R_D8).one(RegisterType.A).ret());
            instructions.Add(0x3D, IBuilder.type(InstructionType.DEC).addr(AddressMode.R).one(RegisterType.A).ret());
            instructions.Add(0x3F, IBuilder.type(InstructionType.CCF).ret());

            instructions.Add(0x40, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.B).two(RegisterType.B).ret());
            instructions.Add(0x41, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.B).two(RegisterType.C).ret());
            instructions.Add(0x42, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.B).two(RegisterType.D).ret());
            instructions.Add(0x43, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.B).two(RegisterType.E).ret());
            instructions.Add(0x44, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.B).two(RegisterType.H).ret());
            instructions.Add(0x45, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.B).two(RegisterType.L).ret());
            instructions.Add(0x46, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.B).two(RegisterType.HL).ret());
            instructions.Add(0x47, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.B).two(RegisterType.A).ret());
            instructions.Add(0x48, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.C).two(RegisterType.B).ret());
            instructions.Add(0x49, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.C).two(RegisterType.C).ret());
            instructions.Add(0x4A, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.C).two(RegisterType.D).ret());
            instructions.Add(0x4B, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.C).two(RegisterType.E).ret());
            instructions.Add(0x4C, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.C).two(RegisterType.H).ret());
            instructions.Add(0x4D, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.C).two(RegisterType.L).ret());
            instructions.Add(0x4E, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.C).two(RegisterType.HL).ret());
            instructions.Add(0x4F, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.C).two(RegisterType.A).ret());

            instructions.Add(0x50, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.D).two(RegisterType.B).ret());
            instructions.Add(0x51, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.D).two(RegisterType.C).ret());
            instructions.Add(0x52, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.D).two(RegisterType.D).ret());
            instructions.Add(0x53, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.D).two(RegisterType.E).ret());
            instructions.Add(0x54, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.D).two(RegisterType.H).ret());
            instructions.Add(0x55, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.D).two(RegisterType.L).ret());
            instructions.Add(0x56, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.D).two(RegisterType.HL).ret());
            instructions.Add(0x57, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.D).two(RegisterType.A).ret());
            instructions.Add(0x58, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.E).two(RegisterType.B).ret());
            instructions.Add(0x59, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.E).two(RegisterType.C).ret());
            instructions.Add(0x5A, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.E).two(RegisterType.D).ret());
            instructions.Add(0x5B, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.E).two(RegisterType.E).ret());
            instructions.Add(0x5C, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.E).two(RegisterType.H).ret());
            instructions.Add(0x5D, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.E).two(RegisterType.L).ret());
            instructions.Add(0x5E, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.E).two(RegisterType.HL).ret());
            instructions.Add(0x5F, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.E).two(RegisterType.A).ret());

            instructions.Add(0x60, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.H).two(RegisterType.B).ret());
            instructions.Add(0x61, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.H).two(RegisterType.C).ret());
            instructions.Add(0x62, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.H).two(RegisterType.D).ret());
            instructions.Add(0x63, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.H).two(RegisterType.E).ret());
            instructions.Add(0x64, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.H).two(RegisterType.H).ret());
            instructions.Add(0x65, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.H).two(RegisterType.L).ret());
            instructions.Add(0x66, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.H).two(RegisterType.HL).ret());
            instructions.Add(0x67, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.H).two(RegisterType.A).ret());
            instructions.Add(0x68, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.L).two(RegisterType.B).ret());
            instructions.Add(0x69, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.L).two(RegisterType.C).ret());
            instructions.Add(0x6A, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.L).two(RegisterType.D).ret());
            instructions.Add(0x6B, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.L).two(RegisterType.E).ret());
            instructions.Add(0x6C, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.L).two(RegisterType.H).ret());
            instructions.Add(0x6D, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.L).two(RegisterType.L).ret());
            instructions.Add(0x6E, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.L).two(RegisterType.HL).ret());
            instructions.Add(0x6F, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.L).two(RegisterType.A).ret());

            instructions.Add(0x70, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.HL).two(RegisterType.B).ret());
            instructions.Add(0x71, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.HL).two(RegisterType.C).ret());
            instructions.Add(0x72, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.HL).two(RegisterType.D).ret());
            instructions.Add(0x73, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.HL).two(RegisterType.E).ret());
            instructions.Add(0x74, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.HL).two(RegisterType.H).ret());
            instructions.Add(0x75, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.HL).two(RegisterType.L).ret());
            instructions.Add(0x76, IBuilder.type(InstructionType.HALT).ret());
            instructions.Add(0x77, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.HL).two(RegisterType.A).ret());
            instructions.Add(0x78, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.B).ret());
            instructions.Add(0x79, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0x7A, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.D).ret());
            instructions.Add(0x7B, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.E).ret());
            instructions.Add(0x7C, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.H).ret());
            instructions.Add(0x7D, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.L).ret());
            instructions.Add(0x7E, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0x7F, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.A).ret());

            instructions.Add(0x80, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.B).ret());
            instructions.Add(0x81, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0x82, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.D).ret());
            instructions.Add(0x83, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.E).ret());
            instructions.Add(0x84, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.H).ret());
            instructions.Add(0x85, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.L).ret());
            instructions.Add(0x86, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0x87, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.A).ret());
            instructions.Add(0x88, IBuilder.type(InstructionType.ADC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.B).ret());
            instructions.Add(0x89, IBuilder.type(InstructionType.ADC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0x8A, IBuilder.type(InstructionType.ADC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.D).ret());
            instructions.Add(0x8B, IBuilder.type(InstructionType.ADC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.E).ret());
            instructions.Add(0x8C, IBuilder.type(InstructionType.ADC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.H).ret());
            instructions.Add(0x8D, IBuilder.type(InstructionType.ADC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.L).ret());
            instructions.Add(0x8E, IBuilder.type(InstructionType.ADC).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0x8F, IBuilder.type(InstructionType.ADC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.A).ret());

            instructions.Add(0x90, IBuilder.type(InstructionType.SUB).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.B).ret());
            instructions.Add(0x91, IBuilder.type(InstructionType.SUB).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0x92, IBuilder.type(InstructionType.SUB).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.D).ret());
            instructions.Add(0x93, IBuilder.type(InstructionType.SUB).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.E).ret());
            instructions.Add(0x94, IBuilder.type(InstructionType.SUB).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.H).ret());
            instructions.Add(0x95, IBuilder.type(InstructionType.SUB).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.L).ret());
            instructions.Add(0x96, IBuilder.type(InstructionType.SUB).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0x97, IBuilder.type(InstructionType.SUB).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.A).ret());
            instructions.Add(0x98, IBuilder.type(InstructionType.SBC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.B).ret());
            instructions.Add(0x99, IBuilder.type(InstructionType.SBC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0x9A, IBuilder.type(InstructionType.SBC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.D).ret());
            instructions.Add(0x9B, IBuilder.type(InstructionType.SBC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.E).ret());
            instructions.Add(0x9C, IBuilder.type(InstructionType.SBC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.H).ret());
            instructions.Add(0x9D, IBuilder.type(InstructionType.SBC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.L).ret());
            instructions.Add(0x9E, IBuilder.type(InstructionType.SBC).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0x9F, IBuilder.type(InstructionType.SBC).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.A).ret());

            instructions.Add(0xA0, IBuilder.type(InstructionType.AND).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.B).ret());
            instructions.Add(0xA1, IBuilder.type(InstructionType.AND).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0xA2, IBuilder.type(InstructionType.AND).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.D).ret());
            instructions.Add(0xA3, IBuilder.type(InstructionType.AND).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.E).ret());
            instructions.Add(0xA4, IBuilder.type(InstructionType.AND).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.H).ret());
            instructions.Add(0xA5, IBuilder.type(InstructionType.AND).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.L).ret());
            instructions.Add(0xA6, IBuilder.type(InstructionType.AND).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0xA7, IBuilder.type(InstructionType.AND).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.A).ret());
            instructions.Add(0xA8, IBuilder.type(InstructionType.XOR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.B).ret());
            instructions.Add(0xA9, IBuilder.type(InstructionType.XOR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0xAA, IBuilder.type(InstructionType.XOR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.D).ret());
            instructions.Add(0xAB, IBuilder.type(InstructionType.XOR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.E).ret());
            instructions.Add(0xAC, IBuilder.type(InstructionType.XOR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.H).ret());
            instructions.Add(0xAD, IBuilder.type(InstructionType.XOR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.L).ret());
            instructions.Add(0xAE, IBuilder.type(InstructionType.XOR).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0xAF, IBuilder.type(InstructionType.XOR).addr(AddressMode.R).one(RegisterType.A).ret());

            instructions.Add(0xB0, IBuilder.type(InstructionType.OR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.B).ret());
            instructions.Add(0xB1, IBuilder.type(InstructionType.OR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0xB2, IBuilder.type(InstructionType.OR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.D).ret());
            instructions.Add(0xB3, IBuilder.type(InstructionType.OR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.E).ret());
            instructions.Add(0xB4, IBuilder.type(InstructionType.OR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.H).ret());
            instructions.Add(0xB5, IBuilder.type(InstructionType.OR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.L).ret());
            instructions.Add(0xB6, IBuilder.type(InstructionType.OR).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0xB7, IBuilder.type(InstructionType.OR).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.A).ret());
            instructions.Add(0xB8, IBuilder.type(InstructionType.CP).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.B).ret());
            instructions.Add(0xB9, IBuilder.type(InstructionType.CP).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0xBA, IBuilder.type(InstructionType.CP).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.D).ret());
            instructions.Add(0xBB, IBuilder.type(InstructionType.CP).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.E).ret());
            instructions.Add(0xBC, IBuilder.type(InstructionType.CP).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.H).ret());
            instructions.Add(0xBD, IBuilder.type(InstructionType.CP).addr(AddressMode.R_R).one(RegisterType.A).two(RegisterType.L).ret());
            instructions.Add(0xBE, IBuilder.type(InstructionType.CP).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.HL).ret());
            instructions.Add(0xBF, IBuilder.type(InstructionType.CP).addr(AddressMode.R).one(RegisterType.A).ret());

            instructions.Add(0xC0, IBuilder.type(InstructionType.RET).cond(ConditionType.NZ).ret());
            instructions.Add(0xC1, IBuilder.type(InstructionType.POP).one(RegisterType.BC).ret());
            instructions.Add(0xC2, IBuilder.type(InstructionType.JP).addr(AddressMode.D16).cond(ConditionType.NZ).ret());
            instructions.Add(0xC3, IBuilder.type(InstructionType.JP).addr(AddressMode.D16).ret());
            instructions.Add(0xC4, IBuilder.type(InstructionType.CALL).addr(AddressMode.D16).cond(ConditionType.NZ).ret());
            instructions.Add(0xC5, IBuilder.type(InstructionType.PUSH).one(RegisterType.BC).ret());
            instructions.Add(0xC6, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_D8).one(RegisterType.A).ret());
            instructions.Add(0xC7, IBuilder.type(InstructionType.RST).param(0x00).ret());
            instructions.Add(0xC8, IBuilder.type(InstructionType.RET).cond(ConditionType.Z).ret());
            instructions.Add(0xC9, IBuilder.type(InstructionType.RET).ret());
            instructions.Add(0xCA, IBuilder.type(InstructionType.JP).addr(AddressMode.D16).cond(ConditionType.Z).ret());
            instructions.Add(0xCC, IBuilder.type(InstructionType.CALL).addr(AddressMode.D16).cond(ConditionType.Z).ret());
            instructions.Add(0xCB, IBuilder.type(InstructionType.CB).addr(AddressMode.D8).ret());
            instructions.Add(0xCD, IBuilder.type(InstructionType.CALL).addr(AddressMode.D16).ret());
            instructions.Add(0xCE, IBuilder.type(InstructionType.ADC).addr(AddressMode.R_D8).one(RegisterType.A).ret());
            instructions.Add(0xCF, IBuilder.type(InstructionType.RST).param(0x08).ret());

            instructions.Add(0xD0, IBuilder.type(InstructionType.RET).cond(ConditionType.NC).ret());
            instructions.Add(0xD1, IBuilder.type(InstructionType.POP).one(RegisterType.DE).ret());
            instructions.Add(0xD2, IBuilder.type(InstructionType.JP).addr(AddressMode.D16).cond(ConditionType.NC).ret());
            instructions.Add(0xD4, IBuilder.type(InstructionType.CALL).addr(AddressMode.D16).cond(ConditionType.NC).ret());
            instructions.Add(0xD5, IBuilder.type(InstructionType.PUSH).one(RegisterType.DE).ret());
            instructions.Add(0xD6, IBuilder.type(InstructionType.SUB).addr(AddressMode.R_D8).ret());
            instructions.Add(0xD7, IBuilder.type(InstructionType.RST).param(0x10).ret());
            instructions.Add(0xD8, IBuilder.type(InstructionType.RET).cond(ConditionType.C).ret());
            instructions.Add(0xD9, IBuilder.type(InstructionType.RETI).ret());
            instructions.Add(0xDA, IBuilder.type(InstructionType.JP).addr(AddressMode.D16).cond(ConditionType.C).ret());
            instructions.Add(0xDC, IBuilder.type(InstructionType.CALL).addr(AddressMode.D16).cond(ConditionType.C).ret());
            instructions.Add(0xDE, IBuilder.type(InstructionType.SBC).addr(AddressMode.R_D8).one(RegisterType.A).ret());
            instructions.Add(0xDF, IBuilder.type(InstructionType.RST).param(0x18).ret());

            instructions.Add(0xE0, IBuilder.type(InstructionType.LDH).addr(AddressMode.A8_R).one(RegisterType.NONE).two(RegisterType.A).ret());
            instructions.Add(0xE1, IBuilder.type(InstructionType.POP).one(RegisterType.HL).ret());
            instructions.Add(0xE2, IBuilder.type(InstructionType.LD).addr(AddressMode.MR_R).one(RegisterType.C).two(RegisterType.A).ret());
            instructions.Add(0xE5, IBuilder.type(InstructionType.PUSH).one(RegisterType.HL).ret());
            instructions.Add(0xE6, IBuilder.type(InstructionType.AND).addr(AddressMode.D8).ret());
            instructions.Add(0xE7, IBuilder.type(InstructionType.RST).param(0x20).ret());
            instructions.Add(0xE8, IBuilder.type(InstructionType.ADD).addr(AddressMode.R_D8).one(RegisterType.SP).ret());
            instructions.Add(0xE9, IBuilder.type(InstructionType.JP).addr(AddressMode.MR).one(RegisterType.HL).ret());
            instructions.Add(0xEA, IBuilder.type(InstructionType.LD).addr(AddressMode.A16_R).one(RegisterType.NONE).two(RegisterType.A).ret());
            instructions.Add(0xEE, IBuilder.type(InstructionType.XOR).addr(AddressMode.D8).ret());
            instructions.Add(0xEF, IBuilder.type(InstructionType.RST).param(0x28).ret());

            instructions.Add(0xF0, IBuilder.type(InstructionType.LDH).addr(AddressMode.R_A8).one(RegisterType.A).ret());
            instructions.Add(0xF2, IBuilder.type(InstructionType.LD).addr(AddressMode.R_MR).one(RegisterType.A).two(RegisterType.C).ret());
            instructions.Add(0xF1, IBuilder.type(InstructionType.POP).one(RegisterType.AF).ret());
            instructions.Add(0xF3, IBuilder.type(InstructionType.DI).ret());
            instructions.Add(0xF5, IBuilder.type(InstructionType.PUSH).one(RegisterType.AF).ret());
            instructions.Add(0xF6, IBuilder.type(InstructionType.OR).addr(AddressMode.D8).ret());
            instructions.Add(0xF8, IBuilder.type(InstructionType.LD).addr(AddressMode.HL_SPR).one(RegisterType.HL).two(RegisterType.SP).ret());
            instructions.Add(0xF9, IBuilder.type(InstructionType.LD).addr(AddressMode.R_R).one(RegisterType.SP).two(RegisterType.HL).ret());
            instructions.Add(0xFA, IBuilder.type(InstructionType.LD).addr(AddressMode.R_A16).one(RegisterType.A).ret());
            instructions.Add(0xFB, IBuilder.type(InstructionType.EI).ret());
            instructions.Add(0xFE, IBuilder.type(InstructionType.CP).addr(AddressMode.D8).ret());
            instructions.Add(0xFF, IBuilder.type(InstructionType.RST).param(0x38).ret());
        }

    }

    public record Instruction(InstructionType type, AddressMode addr, RegisterType rOne, RegisterType rTwo, ConditionType cond, byte parameter);

    public class IBuilder
    {

        private InstructionType instructionType = InstructionType.NONE;
        private AddressMode addressMode = AddressMode.IMP;
        private RegisterType registerTypeOne = RegisterType.NONE;
        private RegisterType registerTypeTwo = RegisterType.NONE;
        private ConditionType conditionType = ConditionType.NONE;
        private byte parameter;

        public static IBuilder type(InstructionType type)
        {
            IBuilder builder = new IBuilder();
            builder.instructionType = type;
            return builder;
        }

        public IBuilder addr(AddressMode addr)
        {
            addressMode = addr;
            return this;
        }

        public IBuilder one(RegisterType one)
        {
            registerTypeOne = one;
            return this;
        }

        public IBuilder two(RegisterType two)
        {
            registerTypeTwo = two;
            return this;
        }

        public IBuilder cond(ConditionType cond)
        {
            conditionType = cond;
            return this;
        }

        public IBuilder param(byte cond)
        {
            parameter = cond;
            return this;
        }

        public Instruction ret()
        {
            return new Instruction(
                    instructionType,
                    addressMode,
                    registerTypeOne,
                    registerTypeTwo,
                    conditionType,
                    parameter
            );
        }
    }

}