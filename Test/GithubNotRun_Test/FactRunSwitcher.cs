using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GithubNotRunning
{
    // Uncomment to enable tests
    //public class FactSwitch : FactAttribute { }

    // Uncomment to disable tests
    internal class FactSwitch : Attribute { }
}
