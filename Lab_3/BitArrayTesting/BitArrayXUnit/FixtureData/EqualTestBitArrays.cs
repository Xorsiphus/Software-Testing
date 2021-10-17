using System.Collections;
using System.Collections.Generic;

namespace BitArrayXUnit.FixtureData
{
    /// <summary>
    /// Data class for equality test
    /// </summary>
    public class EqualTestBitArrays : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new BitArray(new[] { true, false }), // param
                new BitArray(new[] { true, false }), // result
                true
            };
            yield return new object[]
            {
                new BitArray(new[] { false, false }), // param
                new BitArray(new[] { false, false }), // result
                true
            };
            yield return new object[]
            {
                new BitArray(new[] { true, false }), // param
                new BitArray(new[] { true, true }), // result
                false
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}