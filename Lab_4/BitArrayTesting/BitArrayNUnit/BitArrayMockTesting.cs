using System;
using System.Collections;
using BitArrayExtensions.Calc;
using BitArrayExtensions.Parser;
using Moq;
using NUnit.Framework;

namespace BitArrayNUnit
{
    public class MockTests
    {
        private Mock<IBitArrayParser> _mockParser;

        [SetUp]
        public void Setup()
        {
            _mockParser = new Mock<IBitArrayParser>();
            _mockParser.Setup(p => p.ParseArrayValue("101")).Returns(new BitArray(new[] {true, false, true}));
            _mockParser.Setup(p => p.ParseArrayValue("1001")).Returns(new BitArray(new[] {true, false, false, true}));
            _mockParser.Setup(p => p.ParseArrayValue("1100")).Returns(new BitArray(new[] {true, true, false, false}));
            _mockParser.Setup(p => p.ParseArrayValue("1010")).Returns(new BitArray(new[] {true, false, true, false}));
            _mockParser.Setup(p => p.ParseArrayValue("1110")).Returns(new BitArray(new[] {true, true, true, false}));
            _mockParser.Setup(p => p.ParseArrayValue("1")).Returns(new BitArray(new[] {true}));
            _mockParser.Setup(p => p.ParseArrayValue("true,false")).Returns(new BitArray(new[] {true, false}));
            
            _mockParser.Setup(p => p.ParseOperation("And")).Returns(BitArrayOperation.And);
            _mockParser.Setup(p => p.ParseOperation("Impl")).Returns(BitArrayOperation.Impl);
            _mockParser.Setup(p => p.ParseOperation("Not")).Returns(BitArrayOperation.Not);
            _mockParser.Setup(p => p.ParseOperation("Comp")).Returns(BitArrayOperation.Comp);
            _mockParser.Setup(p => p.ParseOperation("Or")).Returns(BitArrayOperation.Or);
            
            _mockParser.Setup(p => p.ParseArrayValue(null)).Throws(new ArgumentException("Empty argument!"));
        }

        [Test]
        public void TestWaitingForStartWithMock()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            var result = calc.Step("101");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForStartWithMock2()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            var result = calc.Step("10");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForStartWithMock3()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            var result = calc.Step("101");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForOperationWithMock()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("101");
            var result = calc.Step("And");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }
        
        [Test]
        public void TestWaitingForArgumentWithMock7()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("1110");
            calc.Step("Comp");
            var status = calc.Step("1100");
            var result = calc.GetArray();

            var expected = new BitArray(new[] {true, true, true, false});

            Assert.AreEqual(BitArrayCalcStatus.Success, status);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void TestWaitingForArgumentWithMock8()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("1001");
            calc.Step("Comp");
            var status = calc.Step("1001");
            var result = calc.GetArray();

            var expected = new BitArray(new[] {true, false, false, true});

            Assert.AreEqual(BitArrayCalcStatus.Success, status);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestWaitingForOperationWithMock2()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("101");
            var result = calc.Step("Impl");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForOperationWithMock3()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("101");
            var result = calc.Step("Not");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForArgumentWithMock()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("1001");
            calc.Step("Comp");
            var status = calc.Step("1100");
            var result = calc.GetArray();

            var expected = new BitArray(new[] {true, true, false, false});

            Assert.AreEqual(BitArrayCalcStatus.Success, status);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestWaitingForArgumentWithMock2()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("1010");
            calc.Step("Impl");
            var status = calc.Step("1001");
            var result = calc.GetArray();

            var expected = new BitArray(new[] {true, true, false, true});

            Assert.AreEqual(BitArrayCalcStatus.Success, status);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void TestWaitingForArgumentWithMock3()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("1001");
            calc.Step("And");
            var status = calc.Step("1110");
            var result = calc.GetArray();

            var expected = new BitArray(new[] {true, false, false, false});
            
            Assert.AreEqual(BitArrayCalcStatus.Success, status);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestWaitingForArgumentWithMock4()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("1001");
            calc.Step("Or");
            var status = calc.Step("1");

            Assert.AreEqual(BitArrayCalcStatus.Error, status);
        }
        
        [Test]
        public void TestWaitingForArgumentWithMock5()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("1001");
            calc.Step("Impl");
            var status = calc.Step("1");

            Assert.AreEqual(BitArrayCalcStatus.Error, status);
        }
        
        [Test]
        public void TestWaitingForArgumentWithMock6()
        {
            var calc = new BitArrayCalc(_mockParser.Object);

            calc.Step("1001");
            calc.Step("Comp");
            var status = calc.Step("1");

            Assert.AreEqual(BitArrayCalcStatus.Error, status);
        }
    }
}