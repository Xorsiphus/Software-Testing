using System.Collections;
using BitArrayExtensions;
using BitArrayExtensions.Parser;
using NUnit.Framework;

namespace BitArrayNUnit
{
    public class CoverageTests
    {
        private readonly IBitArrayParser _parser = new BitArrayParser();
        
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void TestTripleAndTrue()
        {
            var first = _parser.ParseArrayValue("11011");
            var second = _parser.ParseArrayValue("true,True,false,true,true");
            var third = new BitArray(new [] { true, true, false, true, true });

            Assert.True(BitArrayExtension.TripleAnd(first, second, third));
        }
        
        [Test]
        public void TestTripleAndFalse()
        {
            var first = _parser.ParseArrayValue("11011");
            var second = _parser.ParseArrayValue("true,True,false,true,true");
            var third = new BitArray(new [] { true, true, true, true, true });

            Assert.False(BitArrayExtension.TripleAnd(first, second, third));
        }

        [Test]
        public void TestFromNumeric()
        {
            var actual = _parser.ParseArrayValue("110");
            var expected = new BitArray(new [] { true, true, false });

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TestFromBoolean()
        {
            var actual = _parser.ParseArrayValue("true,True,false");
            var expected = new BitArray(new [] { true, true, false });

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TestWrongInput()
        {
            Assert.Catch(() => _parser.ParseArrayValue("wrong input string"));
        }
        
        [Test]
        public void TestNullableInput()
        {
            Assert.Catch(() => _parser.ParseArrayValue(null));
        }
        
        [Test]
        public void TestEmptyInput()
        {
            Assert.Catch(() => _parser.ParseArrayValue(""));
        }
    }
}