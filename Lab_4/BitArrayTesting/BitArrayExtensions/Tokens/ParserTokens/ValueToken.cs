using System.Collections;
using BitArrayExtensions.Parser;

namespace BitArrayExtensions.Tokens.ParserTokens
{
    public class ValueToken : GenericToken<BitArray>
    {
        private readonly IBitArrayParser _parser = new BitArrayParser();
        
        public ValueToken(string value) : base(value)
        {
            Container = _parser.ParseArrayValue(value);
        }
    }
}