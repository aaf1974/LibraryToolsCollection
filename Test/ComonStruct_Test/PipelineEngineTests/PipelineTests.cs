using ComonStruct.PipelineEng;
using Xunit;

namespace SimpleStructTest.PipelineEngineTests
{
    public class PipelineTests
    {
        [Fact]
        public void SampleExecuting()
        {
            Sample_Ctx ctx = new Sample_Ctx() {
                val1 = 5,
                val2 = 20,
                val3 = 4
            };

            new PipelineFabrik()
                .AddTask(new Sample_MultiplicateVal1AndVal2(ctx))
                .AddTask(new Sample_ResDivVal3(ctx))
                .Execute();

            Assert.Equal(25, ctx.res);
        }
    }
}
