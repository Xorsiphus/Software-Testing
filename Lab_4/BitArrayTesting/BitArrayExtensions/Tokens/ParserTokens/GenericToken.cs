namespace BitArrayExtensions.Tokens.ParserTokens
{
    public abstract class GenericToken<T> : IToken
    {
        protected T Container;
        
        protected GenericToken(string value)
        {
        }

        public T GetInsides()
        {
            return Container;
        }
    }
}