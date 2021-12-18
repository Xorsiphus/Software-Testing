using System;
using System.Collections;
using BitArrayExtensions;
using Xunit;

namespace BitArrayXUnit
{
    /// <summary>
    /// Test class
    /// </summary>
    public class UnitTesting
    {
        // first param = 10 : BitArray
        // second param = 11 : BitArray
        
        /// <summary>
        /// Equality test
        /// </summary>
        [Fact]
        public void TestEqualsFirstSet()
        {
            var first = new BitArray(new[] { true, false });
            var second = new BitArray(new[] { true, true });
            
            // 10 != 11
            Assert.False(first.Equals(second));
        }
        
        /// <summary>
        /// Comparison test
        /// </summary>
        [Fact]
        public void TestCompareFirstSet()
        {
            var first = new BitArray(new[] { true, false });
            var second = new BitArray(new[] { true, true });
            
            // 10 < 11 : -1
            Assert.Equal(-1, first.CompareTo(second));
        }
        
        /// <summary>
        /// Boolean "and" test
        /// </summary>
        [Fact]
        public void TestAndFirstSet()
        {
            var first = new BitArray(new[] { true, false });
            var second = new BitArray(new[] { true, true });
            
            // 10 - result
            var result = new BitArray(new[] { true, false });
            
            // 10 && 11 = 10
            Assert.Equal(result, first.And(second));
        }
        
        /// <summary>
        /// Boolean "or" test
        /// </summary>
        [Fact]
        public void TestOrFirstSet()
        {
            var first = new BitArray(new[] { true, false });
            var second = new BitArray(new[] { true, true });
            
            // 11 - result
            var result = new BitArray(new[] { true, true });
            
            // 10 && 11 = 11
            Assert.Equal(result, first.Or(second));
        }
        
        /// <summary>
        /// Inversion test
        /// </summary>
        [Fact]
        public void TestInversionFirstSet()
        {
            var first = new BitArray(new[] { true, false });
            var second = new BitArray(new[] { true, true });
            
            // 01 - first result
            var firstResult = new BitArray(new[] { false, true });
            // 00 - second result
            var secondResult = new BitArray(new[] { false, false });
            
            // !10 = 01
            Assert.Equal(firstResult, first.Not());
            // !11 = 00
            Assert.Equal(secondResult, second.Not());
        }
        
        /// <summary>
        /// Material Implication test
        /// </summary>
        [Fact]
        public void TestMaterialImplicationFirstSet()
        {
            var first = new BitArray(new[] { true, false });
            var second = new BitArray(new[] { true, true });
            
            // 11 - result
            var result = new BitArray(new[] { true, true });
            
            // 10 -> 11 = 11
            Assert.Equal(result, first.MaterialImplication(second));
        }
        
        /// <summary>
        /// Equality exception test
        /// </summary>
        [Fact]
        public void TestEqualsException()
        {
            var first = new BitArray(new[] { true, false, true });
            var second = new BitArray(new[] { true, true });

            Assert.Throws<ArgumentException>(() => first.Equal(second));
        }
        
        /// <summary>
        /// Comparison exception test
        /// </summary>
        [Fact]
        public void TestCompareException()
        {
            var first = new BitArray(new[] { true, false, true });
            var second = new BitArray(new[] { true, true });
            
            Assert.Throws<ArgumentException>(() => first.CompareTo(second));
        }
        
        /// <summary>
        /// Material Implication exception test
        /// </summary>
        [Fact]
        public void TestMaterialImplicationException()
        {
            var first = new BitArray(new[] { true, false, true });
            var second = new BitArray(new[] { true, true });
        
            Assert.Throws<ArgumentException>(() => first.MaterialImplication(second));
        }
    }
}