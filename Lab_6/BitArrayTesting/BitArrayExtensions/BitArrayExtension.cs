using System;
using System.Collections;
using System.Text.RegularExpressions;
using CustomContractImplementation;

namespace BitArrayExtensions
{
    /// <summary>
    /// Extension methods class
    /// </summary>
    public static class BitArrayExtension
    {
        /// <summary>
        /// Extension method adding Equality functionality
        /// </summary>
        /// <param name="firstArray">First array of bits to compute</param>
        /// <param name="secondArray">Second array of bits to compute</param>
        /// <returns>Equality result</returns>
        /// <exception cref="ArgumentException">Array lengths must be the same</exception>
        public static bool Equal(this BitArray firstArray, BitArray secondArray)
        {
            CustomContract.Requires<NullReferenceException>(firstArray != null, "firstArray != null");
            CustomContract.Requires<NullReferenceException>(secondArray != null, "secondArray != null");
            CustomContract.Requires<NullReferenceException>(firstArray.Length > 0, "firstArray.Length > 0");
            CustomContract.Requires<NullReferenceException>(secondArray.Length > 0, "secondArray.Length > 0");
                
            if (firstArray.Length != secondArray.Length)
                throw new ArgumentException("Array lengths must be the same.");

            for (var i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Extension method adding Material Implication functionality
        /// </summary>
        /// <param name="firstArray">First array of bits to compute</param>
        /// <param name="secondArray">Second array of bits to compute</param>
        /// <returns>Material Implication result</returns>
        /// <exception cref="ArgumentException">Array lengths must be the same</exception>
        public static BitArray MaterialImplication(this BitArray firstArray, BitArray secondArray)
        {
            CustomContract.Requires<NullReferenceException>(firstArray != null, "firstArray != null");
            CustomContract.Requires<NullReferenceException>(secondArray != null, "secondArray != null");
            CustomContract.Requires<NullReferenceException>(firstArray.Length > 0, "firstArray.Length > 0");
            CustomContract.Requires<NullReferenceException>(secondArray.Length > 0, "secondArray.Length > 0");
            
            if (firstArray.Length != secondArray.Length)
                throw new ArgumentException("Array lengths must be the same.");

            bool[] result = new bool[firstArray.Length];

            for (var i = 0;
                i < firstArray.Length;
                i++)
            {
                result[i] = !firstArray[i] | secondArray[i];
                Console.WriteLine(result[i]);
            }

            return new BitArray(result);
        }

        /// <summary>
        /// Extension method adding Compare functionality
        /// </summary>
        /// <param name="firstArray">First array of bits to compute</param>
        /// <param name="secondArray">Second array of bits to compute</param>
        /// <returns>Comparison result</returns>
        /// <exception cref="ArgumentException">Array lengths must be the same</exception>
        public static int CompareTo(this BitArray firstArray, BitArray secondArray)
        {
            CustomContract.Requires<NullReferenceException>(firstArray != null, "firstArray != null");
            CustomContract.Requires<NullReferenceException>(secondArray != null, "secondArray != null");
            CustomContract.Requires<NullReferenceException>(firstArray.Length > 0, "firstArray.Length > 0");
            CustomContract.Requires<NullReferenceException>(secondArray.Length > 0, "secondArray.Length > 0");
            
            if (firstArray.Length != secondArray.Length)
                throw new ArgumentException("Array lengths must be the same.");

            for (var i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] && !secondArray[i])
                    return 1;
                if (!firstArray[i] && secondArray[i])
                    return -1;
            }

            return 0;
        }

        /// <summary>
        /// Extension method allows translate a string to BitArray instance
        /// </summary>
        /// <param name="input">String to convert</param>
        /// <returns>BitArray instance obtained as a result of conversion</returns>
        /// <exception cref="ArgumentException">Empty or invalid input string format</exception>
        public static BitArray ParseFromString(string input)
        {
            CustomContract.Requires<NullReferenceException>(input != null, "input != null");
            CustomContract.Requires<NullReferenceException>(input.Length > 0, "input.Length > 0");

            // if (input == null || input.Length == 0)
            // {
            //     throw new ArgumentException("Empty argument!");
            // }

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

        /// <summary>
        /// Extension "triple and" method
        /// </summary>
        /// <param name="first">First BitArray instance for comparison</param>
        /// <param name="second">Second BitArray instance for comparison</param>
        /// <param name="third">Third BitArray instance for comparison</param>
        /// <returns>"Triple and" result</returns>
        public static bool TripleAnd(BitArray first, BitArray second, BitArray third)
        {
            CustomContract.Requires<NullReferenceException>(first != null, "first != null");
            CustomContract.Requires<NullReferenceException>(first.Length > 0, "first.Length > 0");
            CustomContract.Requires<NullReferenceException>(second != null, "second != null");
            CustomContract.Requires<NullReferenceException>(second.Length > 0, "second.Length > 0");
            CustomContract.Requires<NullReferenceException>(third != null, "third != null");
            CustomContract.Requires<NullReferenceException>(third.Length > 0, "third.Length > 0");
            return first.Equal(second) && second.Equal(third);
        }
    }
}