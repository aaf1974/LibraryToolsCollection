using System;
using System.Collections.Generic;
using System.Text;

namespace EfToolLibrary.RepoTool
{
    public interface IObservableEntity
    {
        bool IsDeleted { get; set; }

        DateTime DateChanged { get; set; }
    }
}
