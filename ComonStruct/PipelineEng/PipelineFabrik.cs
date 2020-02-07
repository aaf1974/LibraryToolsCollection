using System.Collections.Generic;

namespace ComonStruct.PipelineEng
{
    public class PipelineFabrik
    {
        List<IPipelineTask> _taskElelements = new List<IPipelineTask>();

        public PipelineFabrik AddTask(IPipelineTask task)
        {
            _taskElelements.Add(task);
            return this;
        }


        public void Execute()
        {
            int taskCount = _taskElelements.Count;
            for (int i = 0; i < taskCount; i++)
            {
                _taskElelements[i].Execute();
            }
        }
    }

}

