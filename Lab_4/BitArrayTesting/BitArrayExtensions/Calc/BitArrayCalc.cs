using System;
using System.Collections;
using BitArrayExtensions.Parser;

namespace BitArrayExtensions.Calc
{
    public class BitArrayCalc
    {
        private readonly IBitArrayParser _parser;
        private BitArrayCalcState _state = BitArrayCalcState.WaitingForStart;
        private BitArrayOperation _currentOperation;
        private BitArray _currentArray;

        public BitArrayCalc(IBitArrayParser parser)
        {
            _parser = parser;
        }

        public BitArray GetArray()
        {
            return _currentArray;
        }

        public BitArrayCalcStatus Step(string input)
        {
            try
            {
                switch (_state)
                {
                    case BitArrayCalcState.WaitingForStart:
                        _currentArray = _parser.ParseArrayValue(input);
                        break;
                    
                    case BitArrayCalcState.WaitingForOp:
                        _currentOperation = _parser.ParseOperation(input);
                        if (_currentOperation == BitArrayOperation.Not)
                        {
                            MakeNegative();
                        }
                        break;
                    
                    case BitArrayCalcState.WaitingForArg:
                        var arg = _parser.ParseArrayValue(input);
                        MakeOperation(arg);
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BitArrayCalcStatus.Error;
            }
            
            NextState();
            return BitArrayCalcStatus.Success;
        }

        private void MakeNegative()
        {
            _currentArray = _currentArray.Not();
            NextState();
        }

        private void MakeOperation(BitArray arg)
        {
            var firstArray = _currentArray;
            _currentArray = arg;

            var result = _currentOperation switch
            {
                BitArrayOperation.And => firstArray.And(arg),
                BitArrayOperation.Or => firstArray.Or(arg),
                BitArrayOperation.Comp => BitArrayExtension.Compare(firstArray, arg) > 0 ? firstArray : arg,
                BitArrayOperation.Impl => BitArrayExtension.MaterialImplication(firstArray, arg),
                _ => throw new ArgumentOutOfRangeException()
            };

            _currentArray = result;
        }

        private void NextState()
        {
            _state = _state switch
            {
                BitArrayCalcState.WaitingForStart => BitArrayCalcState.WaitingForOp,
                BitArrayCalcState.WaitingForArg => BitArrayCalcState.WaitingForOp,
                BitArrayCalcState.WaitingForOp => BitArrayCalcState.WaitingForArg,
                _ => BitArrayCalcState.WaitingForStart
            };
        }
    }
}