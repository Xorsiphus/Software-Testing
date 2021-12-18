using System.Collections;
using System.Collections.Generic;

namespace BitArrayXUnit.FixtureData
{
    /// <summary>
    /// Data class for boolean "or" test
    /// </summary>
    public class BOrTestBitsArrays : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new BitArray(new[] { false, false }), // param
                new BitArray(new[] { true, false }), // param
                new BitArray(new[] { true, false }), // result
            };
            yield return new object[]
            {
                new BitArray(new[] { true, true }), // param
                new BitArray(new[] { false, true }), // param
                new BitArray(new[] { true, true }), // result
            };
            yield return new object[]
            {
                new BitArray(new[] { false, false }), // param
                new BitArray(new[] { false, false }), // param
                new BitArray(new[] { false, false }), // result
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}