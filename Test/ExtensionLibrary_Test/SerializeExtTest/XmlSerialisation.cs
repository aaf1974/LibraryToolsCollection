using ExtensionLibrary.SerializeExt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ExtensionLibraryTest.SerializeExtTest
{
    public class XmlSerialisation
    {
        //[Serializable]
        public class serializeObj
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }


        [Fact]
        public void ToXml()
        {
            serializeObj obj = new serializeObj { Id = 1111, Name = "56464" };

            string xml = obj.LtcToXml();
            Assert.False(string.IsNullOrEmpty(xml));
        }

        [Fact]
        public void FromXml()
        {
            serializeObj obj = new serializeObj { Id = 1111, Name = "56464" };
            string xml = obj.LtcToXml();

            serializeObj restored = xml.LtcFromXml<serializeObj>();
            Assert.NotNull(restored);

            Assert.Equal(obj.Id, restored.Id);
            Assert.Equal(obj.Name, restored.Name);
        }

        [Fact]
        public void StreamToXml()
        {
            serializeObj obj = new serializeObj { Id = 1111, Name = "56464" };
            serializeObj restore;
            using (var stream = new MemoryStream())
            {
                //Serialize to stream
                obj.LtcToXml(stream);

                stream.Position = 0;
                //Deserialize
                restore = stream.LtcFromXml<serializeObj>();
            }

            Assert.NotNull(restore);
        }
    }
}
