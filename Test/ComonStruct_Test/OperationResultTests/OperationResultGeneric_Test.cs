using ComonStruct.Result;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace SimpleStructTest.OperationResultTests
{
    public class OperationResultGeneric_Test
    {
        class ResultMessages : IEnumerable<object[]>
        {
            List<object[]> _data = new List<object[]>() {
                new object[] {"Any", 1222 },
                new object[] {"Wrong", 0 }
            };
            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator() => GetEnumerator();
        }

        class OrTestClass
        {
            public OrTestClass(string value)
            {
                Value = value;
            }

            public string Value { get; }

            public override bool Equals(object obj)
            {
                return obj is OrTestClass @class &&
                       Value == @class.Value;
            }

            public override int GetHashCode()
            {
                return Value.GetHashCode();
            }
        }


        [Theory]
        [ClassData(typeof(ResultMessages))]
        public void CreateSucces(string message, int value)
        {
            var r = OperationResult<int>.Success(message, value);

            Assert.NotNull(r);
            Assert.Equal(message, r.Message);
            Assert.Equal(value, r.Value);
            Assert.True(r.Result);
        }


        [Theory]
        [ClassData(typeof(ResultMessages))]
        public void CreateFault(string message, int value)
        {
            var r = OperationResult<int>.Fault(message, value);

            Assert.NotNull(r);
            Assert.Equal(message, r.Message);
            Assert.Equal(value, r.Value);
            Assert.False(r.Result);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BooleanCompare(bool result)
        {
            var r = result ? OperationResult<int>.Success("anyMessage", 1) : OperationResult<int>.Fault("anyMessage", 1);

            Assert.True(r == result);
            Assert.Equal(1, r.Value);
            Assert.Equal("anyMessage", r.Message);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WihoutMessageBooleanCompare(bool result)
        {
            var r = result ? OperationResult<int>.Success(25) : OperationResult<int>.Fault(25);

            Assert.True(r == result);
            Assert.Equal(25, r.Value);
        }

        [Fact]
        public void ValueObjectEqualTest()
        {
            OrTestClass any = new OrTestClass("AnyString");
            var res = OperationResult<OrTestClass>.Success(any);

            Assert.Equal(any, res.Value);
        }
    }
}
