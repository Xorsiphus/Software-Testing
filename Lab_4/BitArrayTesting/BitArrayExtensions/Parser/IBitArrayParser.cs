using System.Collections;
using BitArrayExtensions.Calc;

namespace BitArrayExtensions.Parser
{
    public interface IBitArrayParser
    {
        BitArray ParseArrayValue(string input);
        BitArrayOperation ParseOperation(string input);
    }
}