namespace ComonStruct.PipelineEng
{
    public interface IPipelineTask
    {
        void Execute();
    }

    public interface IPipelineTask<TCtx>
    {
        void Execute(TCtx ctx);
    }
}

