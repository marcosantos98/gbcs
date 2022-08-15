using Xunit;
using GBCS.GB;

namespace GBCS.GBTest
{
    public class AddressHandlersTest
    {
        [Theory]
        [InlineData(RegisterType.A, RegisterType.B, 0x34, 0x35)]
        [InlineData(RegisterType.H, RegisterType.A, 0x34, 0xA0)]
        public static void R_And_R_R(RegisterType oneReg, RegisterType twoReg, byte one, byte two)
        {
            CPU cpu = new();
            cpu.SetRegister(oneReg, one);
            cpu.SetRegister(twoReg, two);
            cpu.Inst = IBuilder.Type(InstructionType.NONE).One(oneReg).Two(twoReg).Ret();
            AddressDataHandlers.Get(AddressMode.R).Invoke(cpu);
            Assert.Equal(cpu.GetRegister(oneReg), cpu.AddressData);
            AddressDataHandlers.Get(AddressMode.R_R).Invoke(cpu);
            Assert.Equal(cpu.GetRegister(twoReg), cpu.AddressData);
        }

        [Fact]
        public static void A8_R()
        {
            CPU cpu = new();
            AddressDataHandlers.Get(AddressMode.A8_R).Invoke(cpu);
            Assert.True(cpu.PcIsMemDest);
        }

        [Fact]
        public static void RD8_D8_RA8_HLSPR()
        {
            CPU cpu = new();
            {
                cpu.Pc = 0xC001;
            }
            cpu.Mem.Write(0xC001, 69);
            AddressDataHandlers.Get(AddressMode.R_D8).Invoke(cpu);
            Assert.Equal(69, cpu.AddressData);
            cpu.Pc = 0xC001;
            AddressDataHandlers.Get(AddressMode.D8).Invoke(cpu);
            Assert.Equal(69, cpu.AddressData);
            cpu.Pc = 0xC001;
            AddressDataHandlers.Get(AddressMode.R_A8).Invoke(cpu);
            Assert.Equal(69, cpu.AddressData);
            cpu.Pc = 0xC001;
            AddressDataHandlers.Get(AddressMode.HL_SPR).Invoke(cpu);
            Assert.Equal(69, cpu.AddressData);
        }

        [Theory]
        [InlineData(0x34, 0x35, 0x3534)]
        [InlineData(0xF0, 0x0F, 0x0FF0)]
        public static void D16(byte one, byte two, ushort expected)
        {
            CPU cpu = new()
            {
                Pc = 0xC000
            };
            cpu.Mem.Write(0xC000, one);
            cpu.Mem.Write(0xC001, two);
            AddressDataHandlers.Get(AddressMode.R_D16).Invoke(cpu);
            Assert.Equal(expected, cpu.AddressData);
            cpu.Pc = 0xC000;
            AddressDataHandlers.Get(AddressMode.D16).Invoke(cpu);
            Assert.Equal(expected, cpu.AddressData);
        }

        [Theory]
        [InlineData(0x01, 0x01, 0x0101, RegisterType.A, 0xA0)]
        public static void A16R_D16R(byte one, byte two, ushort expected, RegisterType a, byte aVal)
        {
            CPU cpu = new()
            {
                Pc = 0xC000
            };
            cpu.Mem.Write(0xC000, one);
            cpu.Mem.Write(0xC001, two);
            cpu.SetRegister(a, aVal);
            cpu.Inst = IBuilder.Type(InstructionType.NOP).Two(a).Ret();
            AddressDataHandlers.Get(AddressMode.A16_R).Invoke(cpu);
            Assert.Equal(expected, cpu.MemDest);
            Assert.True(cpu.PcIsMemDest);
            Assert.Equal(aVal, cpu.AddressData);
            cpu.Pc = 0xC000;
            AddressDataHandlers.Get(AddressMode.D16_R).Invoke(cpu);
            Assert.Equal(expected, cpu.MemDest);
            Assert.True(cpu.PcIsMemDest);
            Assert.Equal(aVal, cpu.AddressData);
        }
    }
}