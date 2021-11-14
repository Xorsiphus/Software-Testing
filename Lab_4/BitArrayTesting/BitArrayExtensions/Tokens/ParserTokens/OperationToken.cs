using BitArrayExtensions.Calc;
using BitArrayExtensions.Parser;

namespace BitArrayExtensions.Tokens.ParserTokens
{
    public class OperationToken : GenericToken<BitArrayOperation>
    {
        private readonly IBitArrayParser _parser = new BitArrayParser();
        
        public OperationToken(string value) : base(value)
        {
            Container = _parser.ParseOperation(value);
        }
    }
}