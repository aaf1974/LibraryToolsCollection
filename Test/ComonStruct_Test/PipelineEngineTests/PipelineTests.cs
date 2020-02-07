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


        [Fact]
        public void SampleExecuting_Ctx_changing()
        {
            Sample_Ctx ctx = new Sample_Ctx()
            {
                val1 = 5,
                val2 = 20,
                val3 = 2
            };

            var pipe = new PipelineFabrik()
                .AddTask(new Sample_MultiplicateVal1AndVal2(ctx))
                .AddTask(new Sample_ResDivVal3(ctx));

            pipe.Execute();
            Assert.Equal(50, ctx.res);

            ctx.val1 = 10;
            pipe.Execute();
            Assert.Equal(100, ctx.res);
        }

        [Fact]
        public void SampleExecuting_Ctx_recrete()
        {
            Sample_Ctx ctx = new Sample_Ctx()
            {
                val1 = 5,
                val2 = 20,
                val3 = 2
            };

            var pipe = new PipelineFabrik<Sample_Ctx>()
                .AddTask(new Sample_MultiplicateVal1AndVal2_Generic())
                .AddTask(new Sample_ResDivVal3_Generic());

            pipe.Execute(ctx);
            Assert.Equal(50, ctx.res);


            ctx = new Sample_Ctx { val1 = 3, val2 = 20, val3 = 4 };
            pipe.Execute(ctx);
            Assert.Equal(15, ctx.res);
        }

    }
}
