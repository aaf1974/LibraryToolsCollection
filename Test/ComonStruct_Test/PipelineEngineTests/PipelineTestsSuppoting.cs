using ComonStruct.PipelineEng;

namespace SimpleStructTest.PipelineEngineTests
{
    class PipelineTestsSuppoting
    {
    }

    class Sample_Ctx
    {
        public int val1;

        public int val2;

        public int val3;

        public decimal res;
    }


    abstract class Sample_Task : IPipelineTask
    {
        public Sample_Task(Sample_Ctx ctx)
        {
            Ctx = ctx;
        }

        public Sample_Ctx Ctx { get; }

        public abstract void Execute();
    }


    class Sample_MultiplicateVal1AndVal2 : Sample_Task
    {
        public Sample_MultiplicateVal1AndVal2(Sample_Ctx ctx): base(ctx)
        {
        }

        public override void Execute()
        {
            Ctx.res = Ctx.val1 * Ctx.val2;
        }
    }
    class Sample_ResDivVal3 : Sample_Task
    {
        public Sample_ResDivVal3(Sample_Ctx ctx) : base(ctx)
        {
        }

        public override void Execute()
        {
            Ctx.res = Ctx.res / Ctx.val3;
        }
    }
}
