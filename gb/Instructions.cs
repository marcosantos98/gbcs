using GBCS.GB.Insts;

namespace GBCS.GB
{
    public class Instructions
    {
        private readonly IDictionary<byte, Instruction> _insts = new Dictionary<byte, Instruction>();

        public Instructions(CPU cpu)
        {
            _insts[0x00] = new Noop(cpu);
            _insts[0x01] = new LD_BC_D16(cpu);
            _insts[0x02] = new WM_LD_BC_A(cpu);
            _insts[0x03] = new INC_BC(cpu);
            _insts[0x04] = new INC_B(cpu);
            _insts[0x05] = new DEC_B(cpu);
            _insts[0x06] = new LD_B_D8(cpu);
            _insts[0x0C] = new INC_C(cpu);
            _insts[0x0D] = new DEC_C(cpu);
            _insts[0x0E] = new LD_C_D8(cpu);

            _insts[0x11] = new LD_DE_D16(cpu);
            _insts[0x12] = new WM_LD_DE_A(cpu);
            _insts[0x13] = new INC_DE(cpu);
            _insts[0x14] = new INC_D(cpu);
            _insts[0x18] = new JR_R8(cpu);
            _insts[0x1A] = new RM_LD_A_DE(cpu);
            _insts[0x1C] = new INC_E(cpu);
            _insts[0x1D] = new DEC_E(cpu);
            _insts[0x1F] = new RRA(cpu);

            _insts[0x20] = new JR_NZ_R8(cpu);
            _insts[0x21] = new LD_HL_D16(cpu);
            _insts[0x22] = new WM_LD_HLI_A(cpu);
            _insts[0x23] = new INC_HL(cpu);
            _insts[0x24] = new INC_H(cpu);
            _insts[0x25] = new DEC_H(cpu);
            _insts[0x26] = new LD_H_D8(cpu);
            _insts[0x27] = new DAA(cpu);
            _insts[0x28] = new JR_Z_R8(cpu);
            _insts[0x29] = new ADD_HL_HL(cpu);
            _insts[0x2A] = new RM_LD_A_HLI(cpu);
            _insts[0x2C] = new INC_L(cpu);
            _insts[0x2D] = new DEC_L(cpu);
            _insts[0x2F] = new CPL(cpu);

            _insts[0x30] = new JR_NC_R8(cpu);
            _insts[0x31] = new LD_SP_D16(cpu);
            _insts[0x32] = new WM_LD_HLD_A(cpu);
            _insts[0x35] = new RM_DEC_HL(cpu);
            _insts[0x37] = new SCF(cpu);
            _insts[0x38] = new JR_C_R8(cpu);
            _insts[0x3C] = new INC_A(cpu);
            _insts[0x3D] = new DEC_A(cpu);
            _insts[0x3E] = new LD_A_D8(cpu);

            _insts[0x40] = new LD_B_B(cpu);
            _insts[0x46] = new RM_LD_B_HL(cpu);
            _insts[0x47] = new LD_B_A(cpu);
            _insts[0x4E] = new RM_LD_C_HL(cpu);
            _insts[0x4F] = new LD_C_A(cpu);

            _insts[0x56] = new RM_LD_D_HL(cpu);
            _insts[0x57] = new LD_D_A(cpu);
            _insts[0x5F] = new LD_E_A(cpu);

            _insts[0x67] = new LD_H_A(cpu);
            _insts[0x6E] = new RM_LD_L_HL(cpu);
            _insts[0x6F] = new LD_L_A(cpu);

            _insts[0x70] = new WM_LD_HL_B(cpu);
            _insts[0x71] = new WM_LD_HL_C(cpu);
            _insts[0x72] = new WM_LD_HL_D(cpu);
            _insts[0x77] = new WM_LD_HL_A(cpu);
            _insts[0x78] = new LD_A_B(cpu);
            _insts[0x79] = new LD_A_C(cpu);
            _insts[0x7A] = new LD_A_D(cpu);
            _insts[0x7B] = new LD_A_E(cpu);
            _insts[0x7C] = new LD_A_H(cpu);
            _insts[0x7D] = new LD_A_L(cpu);
            _insts[0x7E] = new RM_LD_A_HL(cpu);

            _insts[0xAE] = new RM_XOR_HL(cpu);
            _insts[0xA9] = new XOR_C(cpu);

            _insts[0xB1] = new OR_C(cpu);
            _insts[0xB6] = new RM_OR_HL(cpu);
            _insts[0xB7] = new OR_A(cpu);
            _insts[0xB8] = new CP_B(cpu);
            _insts[0xB9] = new CP_C(cpu);
            _insts[0xBA] = new CP_D(cpu);
            _insts[0xBB] = new CP_E(cpu);

            _insts[0xC1] = new POP_BC(cpu);
            _insts[0xC2] = new JP_NZ_A16(cpu);
            _insts[0xC3] = new JP_A16(cpu);
            _insts[0xC4] = new CALL_NZ_A16(cpu);
            _insts[0xC5] = new PUSH_BC(cpu);
            _insts[0xC6] = new ADD_A_D8(cpu);
            _insts[0xC8] = new RET_Z(cpu);
            _insts[0xC9] = new RET(cpu);
            _insts[0xCB] = new CB(cpu);
            _insts[0xCD] = new CALL_A16(cpu);
            _insts[0xCE] = new ADC_A_D8(cpu);

            _insts[0xD0] = new RET_NC(cpu);
            _insts[0xD1] = new POP_DE(cpu);
            _insts[0xD5] = new PUSH_DE(cpu);
            _insts[0xD6] = new SUB_D8(cpu);
            _insts[0xD8] = new RET_C(cpu);

            _insts[0xE0] = new WM_LDH_A8_A(cpu);
            _insts[0xE1] = new POP_HL(cpu);
            _insts[0xE5] = new PUSH_HL(cpu);
            _insts[0xE6] = new AND_D8(cpu);
            _insts[0xE9] = new JP_HL(cpu);
            _insts[0xEA] = new WM_LD_A16_A(cpu);
            _insts[0xEE] = new XOR_D8(cpu);

            _insts[0xF0] = new RM_LDH_A_A8(cpu);
            _insts[0xF1] = new POP_AF(cpu);
            _insts[0xF3] = new DI(cpu);
            _insts[0xF5] = new PUSH_AF(cpu);
            _insts[0xF8] = new LD_HL_SP_R8(cpu);
            _insts[0xFA] = new RM_LD_A_A16(cpu);
            _insts[0xFB] = new EI(cpu);
            _insts[0xFE] = new CP_D8(cpu);
        }

        public (bool, int) ForOpcode(byte opcode)
        {
            return _insts.ContainsKey(opcode)
                ? _insts[opcode].Run()
                : throw new NotImplementedException("Instruction not implemented! " + opcode.ToString("X2"));
        }

        public Instruction For(byte opcode)
        {
            return _insts[opcode];
        }
    }
}