using BitArrayExtensions.Calc;
using BitArrayExtensions.Parser;

namespace BitArrayExtensions
{
    public class Program
    {
        static void Main()
        {
            var parser = new BitArrayParser();
        
            var calc = new BitArrayCalc(parser);
            calc.Step("1011");
            calc.Step("And");
            calc.Step("1100");
            
            var actual = calc.GetArray();
        }
    }
}