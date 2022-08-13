using Xunit;
using GBCS.GB;

namespace GBCS.GBTest
{
    public class CPUTest
    {

        [Theory]
        [InlineData(RegisterType.A, 0x6, 0x6)]
        [InlineData(RegisterType.B, 0x9, 0x9)]
        [InlineData(RegisterType.C, 0xF, 0xF)]
        [InlineData(RegisterType.D, 0xFF, 0xFF)]
        [InlineData(RegisterType.E, 0xF1, 0xF1)]
        [InlineData(RegisterType.F, 0xF2, 0xF2)]
        [InlineData(RegisterType.H, 0xFA, 0xFA)]
        [InlineData(RegisterType.L, 0xAA, 0xAA)]
        [InlineData(RegisterType.AF, 0x0609, 0x0609)]
        [InlineData(RegisterType.BC, 0x9A00, 0x9A00)]
        [InlineData(RegisterType.DE, 0xF123, 0xF123)]
        [InlineData(RegisterType.HL, 0xFFFF, 0xFFFF)]
        public void GetSetRegister(RegisterType register, ushort value, ushort expected)
        {
            CPU cpu = new();
            cpu.SetRegister(register, value);
            Assert.Equal(expected, cpu.GetRegister(register));
        }

        [Theory]
        [InlineData(0x00, false, false, false, false)]    //----
        [InlineData(0x10, false, false, false, true)]     //---C
        [InlineData(0x20, false, false, true, false)]     //--H-
        [InlineData(0x30, false, false, true, true)]      //--HC
        [InlineData(0x40, false, true, false, false)]     //-N--
        [InlineData(0x50, false, true, false, true)]      //-N-C
        [InlineData(0x60, false, true, true, false)]      //-NH-
        [InlineData(0x70, false, true, true, true)]       //-NHC
        [InlineData(0x80, true, false, false, false)]     //Z---
        [InlineData(0x90, true, false, false, true)]      //Z--C
        [InlineData(0xA0, true, false, true, false)]      //Z-H-
        [InlineData(0xB0, true, false, true, true)]       //Z-HC
        [InlineData(0xC0, true, true, false, false)]      //ZN--
        [InlineData(0xD0, true, true, false, true)]       //ZN-C
        [InlineData(0xE0, true, true, true, false)]       //ZNH-
        [InlineData(0xF0, true, true, true, true)]        //ZNHC
        public void GetSetFlags(byte f, bool zero, bool sub, bool halfCarry, bool carry)
        {
            CPU cpu = new();
            cpu.SetFlags(f);
            Flags flags = cpu.Flags;
            Assert.Equal(zero, flags.Zero);
            Assert.Equal(sub, flags.Substract);
            Assert.Equal(halfCarry, flags.HalfCarry);
            Assert.Equal(carry, flags.Carry);
        }
    }

}
