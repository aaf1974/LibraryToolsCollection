using ExtensionLibrary.DiExt;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Xunit;

namespace ExtensionLibraryTest.DiExtTests
{
    public class RegisterAllTypes
    {
        [Fact]
        public void TestREgisteredByInterface()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.LtcRegisterTypesByInterface<ITestDiInterface>(new[] { typeof(ITestDiInterface).GetTypeInfo().Assembly }, true);
            serviceCollection.AddScoped<TestDiService>();

            IServiceProvider ServiceProvider = serviceCollection.BuildServiceProvider();

            var service = ServiceProvider.GetRequiredService<TestDiService>();

            Assert.NotNull(service._testDi1);
            Assert.NotNull(service._testDi2);

            Assert.NotEmpty(service._testDi1.Hello);
            Assert.NotEmpty(service._testDi2.Hello);

        }
    }


    interface ITestDiInterface 
    { 
        string Hello { get; }
    }

    class TestDi1 : ITestDiInterface
    {
        public string Hello => "Test1 class";
    }

    class TestDi2 : ITestDiInterface 
    {
        public string Hello => "Test2 class";
    }


    class TestDiService
    {
        public TestDi1 _testDi1;
        public TestDi2 _testDi2;

        public TestDiService(TestDi1 testDi1, TestDi2 testDi2)
        {
            _testDi1 = testDi1;
            _testDi2 = testDi2;
        }
    }
}
