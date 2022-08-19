using GBCS.GB;

using Xunit;

namespace GBCS.GBTest
{
    public class CartidgeTest
    {
        [Theory]
        [InlineData("./res/01-special.gb")]
        [InlineData("./res/mem_timing.gb")]
        [InlineData("./res/cpu_instrs.gb")]
        [InlineData("./res/dmg-acid2.gb")]
        public static void CartridgeValidChecksum(string romPath)
        {
            Cartidge cartridge = new(romPath);
            Assert.True(cartridge.HasValidChecksum);
        }
    }
}