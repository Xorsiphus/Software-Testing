using System;
using System.Collections;
using BitArrayExtensions.Calc;
using BitArrayExtensions.Parser;
using Moq;
using NUnit.Framework;

namespace BitArrayNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWaitingForStartWithMock()
        {
            var mock = new Mock<IBitArrayParser>();
            mock.Setup(p => p.ParseArrayValue("101")).Returns(new BitArray(new[] {true, false, true}));

            var calc = new BitArrayCalc(mock.Object);

            var result = calc.Step("101");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForStartWithMock2()
        {
            var mock = new Mock<IBitArrayParser>();
            mock.Setup(p => p.ParseArrayValue("true,false")).Returns(new BitArray(new[] {true, false}));

            var calc = new BitArrayCalc(mock.Object);

            var result = calc.Step("10");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForStartWithMock3()
        {
            var mock = new Mock<IBitArrayParser>();
            mock.Setup(p => p.ParseArrayValue(null)).Throws(new ArgumentException("Empty argument!"));

            var calc = new BitArrayCalc(mock.Object);

            var result = calc.Step("101");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForOperationWithMock()
        {
            var mock = new Mock<IBitArrayParser>();
            mock.Setup(p => p.ParseArrayValue("101")).Returns(new BitArray(new[] {true, false, true}));
            mock.Setup(p => p.ParseOperation("And")).Returns(BitArrayOperation.And);

            var calc = new BitArrayCalc(mock.Object);

            calc.Step("101");
            var result = calc.Step("And");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForOperationWithMock2()
        {
            var mock = new Mock<IBitArrayParser>();
            mock.Setup(p => p.ParseArrayValue("101")).Returns(new BitArray(new[] {true, false, true}));
            mock.Setup(p => p.ParseOperation("Impl")).Returns(BitArrayOperation.Impl);

            var calc = new BitArrayCalc(mock.Object);

            calc.Step("101");
            var result = calc.Step("Impl");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForOperationWithMock3()
        {
            var mock = new Mock<IBitArrayParser>();
            mock.Setup(p => p.ParseArrayValue("101")).Returns(new BitArray(new[] {true, false, true}));
            mock.Setup(p => p.ParseOperation("Not")).Returns(BitArrayOperation.Not);

            var calc = new BitArrayCalc(mock.Object);

            calc.Step("101");
            var result = calc.Step("Not");

            Assert.AreEqual(BitArrayCalcStatus.Success, result);
        }

        [Test]
        public void TestWaitingForArgumentWithMock()
        {
            var mock = new Mock<IBitArrayParser>();
            mock.Setup(p => p.ParseArrayValue("1001")).Returns(new BitArray(new[] {true, false, false, true}));
            mock.Setup(p => p.ParseOperation("Comp")).Returns(BitArrayOperation.Comp);
            mock.Setup(p => p.ParseArrayValue("1100")).Returns(new BitArray(new[] {true, true, false, false}));

            var calc = new BitArrayCalc(mock.Object);

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
            var mock = new Mock<IBitArrayParser>();
            mock.Setup(p => p.ParseArrayValue("1010")).Returns(new BitArray(new[] {true, false, true, false}));
            mock.Setup(p => p.ParseOperation("Impl")).Returns(BitArrayOperation.Impl);
            mock.Setup(p => p.ParseArrayValue("1001")).Returns(new BitArray(new[] {true, false, false, true}));

            var calc = new BitArrayCalc(mock.Object);

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
            var mock = new Mock<IBitArrayParser>();
            mock.Setup(p => p.ParseArrayValue("1001")).Returns(new BitArray(new[] {true, false, false, true}));
            mock.Setup(p => p.ParseOperation("Or")).Returns(BitArrayOperation.Or);
            mock.Setup(p => p.ParseArrayValue("1")).Returns(new BitArray(new[] {true}));

            var calc = new BitArrayCalc(mock.Object);

            calc.Step("1001");
            calc.Step("Or");
            var status = calc.Step("1100");

            Assert.AreEqual(BitArrayCalcStatus.Error, status);
        }
    }
}