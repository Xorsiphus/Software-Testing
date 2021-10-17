using System.Collections;
using BitArrayExtensions;
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
        public void TestFromNumeric()
        {
            var actual = BitArrayExtension.ParseFromString("110");
            var expected = new BitArray(new bool[] { true, true, false });

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TestFromBoolean()
        {
            var actual = BitArrayExtension.ParseFromString("true,True,false");
            var expected = new BitArray(new bool[] { true, true, false });

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TestWrongInput()
        {
            Assert.Catch(() => BitArrayExtension.ParseFromString("wrong input string"));
        }
        
        [Test]
        public void TestNullableInput()
        {
            Assert.Catch(() => BitArrayExtension.ParseFromString(null));
        }
        
        [Test]
        public void TestEmptyInput()
        {
            Assert.Catch(() => BitArrayExtension.ParseFromString(""));
        }
    }
}