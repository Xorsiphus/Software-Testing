using System.Collections;
using BitArrayExtensions;
using BitArrayXUnit.FixtureData;
using Xunit;

namespace BitArrayXUnit
{
    /// <summary>
    /// Test class
    /// </summary>
    public class FixtureUnitTesting
    {

        /// <summary>
        /// Equality test
        /// </summary>
        [Theory]
        [ClassData(typeof(EqualTestBitArrays))]
        public void TestEqualsFirstSet(BitArray first, BitArray second, bool result)
        {
            Assert.Equal(result, first.Equal(second));
        }
        
        /// <summary>
        /// Comparison test
        /// </summary>
        [Theory]
        [ClassData(typeof(CompareTestBitArrays))]
        public void TestCompareFirstSet(BitArray first, BitArray second, int result)
        {
            Assert.Equal(result, first.CompareTo(second));
        }
        
        /// <summary>
        /// Boolean "and" test
        /// </summary>
        [Theory]
        [ClassData(typeof(BAndTestBitArrays))]
        public void TestAndFirstSet(BitArray first, BitArray second, BitArray result)
        {
            Assert.Equal(result, first.And(second));
        }
        
        /// <summary>
        /// Boolean "or" test
        /// </summary>
        [Theory]
        [ClassData(typeof(BOrTestBitsArrays))]
        public void TestOrFirstSet(BitArray first, BitArray second, BitArray result)
        {
            Assert.Equal(result, first.Or(second));
        }
        
        /// <summary>
        /// Inversion test
        /// </summary>
        [Theory]
        [ClassData(typeof(InversionTestBitsArrays))]
        public void TestInversionFirstSet(BitArray first, BitArray result)
        {
            Assert.Equal(first.Not(), result);
        }
        
        /// <summary>
        /// Material Implication test
        /// </summary>
        [Theory]
        [ClassData(typeof(MaterialImplicationTestBitsArrays))]
        public void TestMaterialImplicationFirstSet(BitArray first, BitArray second, BitArray result)
        {
            Assert.Equal(result, first.MaterialImplication(second));
        }
    }
}