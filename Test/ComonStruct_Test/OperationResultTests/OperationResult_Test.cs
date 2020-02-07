using ComonStruct.Result;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace SimpleStructTest.OperationResultTests
{
    public class OperationResult_Test
    {
        class ResultMessages : IEnumerable<object[]>
        {
            List<object[]> _data = new List<object[]>() {
                new object[] {"Any" },
                new object[] {"Wrong" }
            };
            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator() => GetEnumerator();
        }



        [Theory]
        [ClassData(typeof(ResultMessages))]
        public void CreateSucces(string message)
        {
            var r = OperationResult.Success(message);

            Assert.NotNull(r);
            Assert.Equal(message, r.Message);
            Assert.True(r.Result);
        }


        [Theory]
        [ClassData(typeof(ResultMessages))]
        public void CreateFault(string message)
        {
            var r = OperationResult.Fault(message);

            Assert.NotNull(r);
            Assert.Equal(message, r.Message);
            Assert.False(r.Result);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BooleanCompare(bool result)
        {
            var r = result ? OperationResult.Success() : OperationResult.Fault();

            Assert.True(r == result);
        }
    }
}
