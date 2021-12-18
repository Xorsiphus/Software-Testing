using System.Collections;
using BitArrayExtensions;
using Xunit;

namespace BitArrayXUnit
{
    /// <summary>
    /// Test class
    /// </summary>
    public class ParameterisedUnitTesting
    {
        /// <summary>
        /// Equality test
        /// </summary>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, true, false)]
        [InlineData(true, false, false)]
        [InlineData(false, false, true)]
        public void TestEqualsFirstSet(bool first, bool second, bool result)
        {
            var firstArray = new BitArray(new [] { first });
            var secondArray = new BitArray(new [] { second });

            Assert.Equal(result, firstArray.Equal(secondArray));
        }
        
        /// <summary>
        /// Comparison test
        /// </summary>
        [Theory]
        [InlineData(false, false, 0)]
        [InlineData(false, true, -1)]
        [InlineData(true, false, 1)]
        [InlineData(true, true, 0)]
        public void TestCompareFirstSet(bool first, bool second, int result)
        {
            var firstArray = new BitArray(new [] { first });
            var secondArray = new BitArray(new [] { second });
            
            Assert.Equal(result, firstArray.CompareTo(secondArray));
        }
        
        /// <summary>
        /// Boolean "and" test
        /// </summary>
        [Theory]
        [InlineData(false, false, false)]
        [InlineData(false, true, false)]
        [InlineData(true, false, false)]
        [InlineData(true, true, true)]
        public void TestAndFirstSet(bool first, bool second, bool result)
        {
            var firstArray = new BitArray(new [] { first });
            var secondArray = new BitArray(new [] { second });
            var resultArray = new BitArray(new[] { result });
            
            Assert.Equal(resultArray, firstArray.And(secondArray));
        }
        
        /// <summary>
        /// Boolean "or" test
        /// </summary>
        [Theory]
        [InlineData(false, false, false)]
        [InlineData(false, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, true, true)]
        public void TestOrFirstSet(bool first, bool second, bool result)
        {
            var firstArray = new BitArray(new [] { first });
            var secondArray = new BitArray(new [] { second });
            var resultArray = new BitArray(new[] { result });
            
            Assert.Equal(resultArray, firstArray.Or(secondArray));
        }
        
        /// <summary>
        /// Inversion test
        /// </summary>
        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void TestInversionFirstSet(bool first, bool result)
        {
            var firstArray = new BitArray(new [] { first });
            var resultArray = new BitArray(new[] { result });
            
            Assert.Equal(resultArray, firstArray.Not());
        }
        
        /// <summary>
        /// Material Implication test
        /// </summary>
        [Theory]
        [InlineData(false, false, true)]
        [InlineData(false, true, true)]
        [InlineData(true, false, false)]
        [InlineData(true, true, true)]
        public void TestMaterialImplicationFirstSet(bool first, bool second, bool result)
        {
            var firstArray = new BitArray(new [] { first });
            var secondArray = new BitArray(new [] { second });
            var resultArray = new BitArray(new[] { result });

            Assert.Equal(resultArray, firstArray.MaterialImplication(secondArray));
        }
    }
}