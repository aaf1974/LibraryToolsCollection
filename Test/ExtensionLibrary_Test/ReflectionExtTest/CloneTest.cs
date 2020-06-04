using ExtensionLibrary.ReflectionExt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExtensionLibraryTest.ReflectionExtTest
{
    public class CloneTest
    {
        [Serializable]
        class clonableObj
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        [Fact]
        public void Clone()
        {
            clonableObj origin = new clonableObj { Id = 1, Name = "A" };

            clonableObj clone = origin.LtcClone<clonableObj>();

            Assert.False(ReferenceEquals(origin, clone));
            Assert.Equal(origin.Id, clone.Id);
            Assert.Equal(origin.Name, clone.Name);
        }
    }
}
