using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExtensionLibraryTest.EnumExtTests
{
    class EnumExtTestsSupporting
    {
    }

    enum SampleEnum
    {
        [Description("OneDecription")]
        One,
        Two,
        [Display(Name = "ThreeDisplay")]
        Three
    }
}
