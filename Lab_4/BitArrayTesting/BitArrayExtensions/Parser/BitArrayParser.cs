using System;
using System.Collections;
using System.Text.RegularExpressions;
using BitArrayExtensions.Calc;

namespace BitArrayExtensions.Parser
{
    /// <summary>
    /// Extension methods class
    /// </summary>
    public class BitArrayParser : IBitArrayParser
    {
        /// <summary>
        /// Extension method allows translate a string to BitArray instance
        /// </summary>
        /// <param name="input">String to convert</param>
        /// <returns>BitArray instance obtained as a result of conversion</returns>
        /// <exception cref="ArgumentException">Empty or invalid input string format</exception>
        public BitArray ParseArrayValue(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Empty argument!");
            }

            input = input.Replace(" ", "");
            InputType type;

            if (Regex.IsMatch(input, @"^[01]*$", RegexOptions.Compiled | RegexOptions.IgnoreCase))
            {
                type = InputType.Numeric;
            }
            else
            {
                if (Regex.IsMatch(input, @"^(true,|false,)*(true|false){1}$",
                    RegexOptions.Compiled | RegexOptions.IgnoreCase))
                {
                    type = InputType.Boolean;
                }
                else
                {
                    throw new ArgumentException("Incorrect argument.");
                }
            }

            BitArray result = new BitArray(0);

            switch (type)
            {
                case InputType.Boolean:

                    var temp = input.Split(',');
                    var bMediator = new bool[temp.Length];

                    for (var i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].ToLower().Equals("false"))
                        {
                            bMediator[i] = false;
                        }
                        else
                        {
                            bMediator[i] = true;
                        }
                    }

                    result = new BitArray(bMediator);

                    break;

                case InputType.Numeric:

                    var nMediator = new bool[input.Length];

                    for (var i = 0; i < input.Length; i++)
                    {
                        if (input[i] == '0')
                        {
                            nMediator[i] = false;
                        }
                        else
                        {
                            nMediator[i] = true;
                        }
                    }

                    result = new BitArray(nMediator);

                    break;
            }

            return result;
        }

        public BitArrayOperation ParseOperation(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Empty argument!");
            }

            if (!Enum.TryParse(input, out BitArrayOperation result)) throw new ArgumentException("Incorrect argument.");

            return result;
        }
    }
}