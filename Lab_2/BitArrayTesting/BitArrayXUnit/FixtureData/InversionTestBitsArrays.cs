using System.Collections;
using System.Collections.Generic;

namespace BitArrayXUnit.FixtureData
{
    /// <summary>
    /// Data class for inverion test
    /// </summary>
    public class InversionTestBitsArrays : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new BitArray(new[] { false, false }), // param
                new BitArray(new[] { true, true }), // result
            };
            yield return new object[]
            {
                new BitArray(new[] { true, true }), // param
                new BitArray(new[] { false, false }), // result
            };
            yield return new object[]
            {
                new BitArray(new[] { false, true }), // param
                new BitArray(new[] { true, false }), // result
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}