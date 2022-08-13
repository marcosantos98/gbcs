using Xunit;
using GBCS.GB;

namespace GBCS.GBTest
{
    public class CartidgeTest
    {
        [Theory]
        [InlineData("./res/mem_timing.gb")]
        [InlineData("./res/cpu_instrs.gb")]
        [InlineData("./res/dmg-acid2.gb")]
        public static void CartidgeValidChecksum(string romPath)
        {
            Cartidge cartidge = new(romPath);
            Assert.True(cartidge.HasValidChecksum);
        }
    }
}