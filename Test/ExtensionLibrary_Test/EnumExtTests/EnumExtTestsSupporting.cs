using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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


    [Flags]
    enum SampleFlagEnum
    {
        FirstFlag = 1,
        SecondFlag = 2,
        ThreedFlag = 4
    }
}
