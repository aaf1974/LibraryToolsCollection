using ExtensionLibrary.StringExt;
using Xunit;

namespace ExtensionLibraryTest.StringExtTest
{
    public class EncriptTest
    {
        [Fact]
        public void Encript()
        {
            string secret = "My Secret";

            string encoded = secret.LcpEncrypt("mykey");
            Assert.NotEqual(secret, encoded);

            string decoded = encoded.LcpDecrypt("mykey");
            Assert.Equal(secret, decoded);
        }
    }
}
