using System.Collections;
using System.Collections.Generic;

namespace BitArrayXUnit.FixtureData
{
    /// <summary>
    /// Data class for comparison test
    /// </summary>
    public class CompareTestBitArrays : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new BitArray(new[] { true, false }), // param
                new BitArray(new[] { true, false }), // result
                0
            };
            yield return new object[]
            {
                new BitArray(new[] { false, false }), // param
                new BitArray(new[] { true, false }), // result
                -1
            };
            yield return new object[]
            {
                new BitArray(new[] { true, false }), // param
                new BitArray(new[] { false, false }), // result
                1
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}