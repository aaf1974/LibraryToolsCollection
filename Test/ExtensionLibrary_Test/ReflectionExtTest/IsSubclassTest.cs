using ExtensionLibrary.ReflectionExt;
using Xunit;

namespace ExtensionLibraryTest.ReflectionExtTest
{
    public class IsSubclassTest
    {
        [Fact]
        public void Test()
        {
            Assert.True(typeof(ChildGeneric).LtcIsSubClassOfGeneric(typeof(BaseGeneric<>)), " 1");
            Assert.False(typeof(ChildGeneric).LtcIsSubClassOfGeneric(typeof(WrongBaseGeneric<>)), " 2");
            Assert.True(typeof(ChildGeneric).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<>)), " 3");
            Assert.False(typeof(ChildGeneric).LtcIsSubClassOfGeneric(typeof(IWrongBaseGeneric<>)), " 4");
            Assert.True(typeof(IChildGeneric).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<>)), " 5");
            Assert.False(typeof(IWrongBaseGeneric<>).LtcIsSubClassOfGeneric(typeof(ChildGeneric2<>)), " 6");
            Assert.True(typeof(ChildGeneric2<>).LtcIsSubClassOfGeneric(typeof(BaseGeneric<>)), " 7");
            Assert.True(typeof(ChildGeneric2<Class1>).LtcIsSubClassOfGeneric(typeof(BaseGeneric<>)), " 8");
            Assert.True(typeof(ChildGeneric).LtcIsSubClassOfGeneric(typeof(BaseGeneric<Class1>)), " 9");
            Assert.False(typeof(ChildGeneric).LtcIsSubClassOfGeneric(typeof(WrongBaseGeneric<Class1>)), "10");
            Assert.True(typeof(ChildGeneric).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<Class1>)), "11");
            Assert.False(typeof(ChildGeneric).LtcIsSubClassOfGeneric(typeof(IWrongBaseGeneric<Class1>)), "12");
            Assert.True(typeof(IChildGeneric).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<Class1>)), "13");
            Assert.False(typeof(BaseGeneric<Class1>).LtcIsSubClassOfGeneric(typeof(ChildGeneric2<Class1>)), "14");
            Assert.True(typeof(ChildGeneric2<Class1>).LtcIsSubClassOfGeneric(typeof(BaseGeneric<Class1>)), "15");
            Assert.False(typeof(ChildGeneric).LtcIsSubClassOfGeneric(typeof(ChildGeneric)), "16");
            Assert.False(typeof(IChildGeneric).LtcIsSubClassOfGeneric(typeof(IChildGeneric)), "17");
            Assert.False(typeof(IBaseGeneric<>).LtcIsSubClassOfGeneric(typeof(IChildGeneric2<>)), "18");
            Assert.True(typeof(IChildGeneric2<>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<>)), "19");
            Assert.True(typeof(IChildGeneric2<Class1>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<>)), "20");
            Assert.False(typeof(IBaseGeneric<Class1>).LtcIsSubClassOfGeneric(typeof(IChildGeneric2<Class1>)), "21");
            Assert.True(typeof(IChildGeneric2<Class1>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<Class1>)), "22");
            Assert.False(typeof(IBaseGeneric<Class1>).LtcIsSubClassOfGeneric(typeof(BaseGeneric<Class1>)), "23");
            Assert.True(typeof(BaseGeneric<Class1>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<Class1>)), "24");
            Assert.False(typeof(IBaseGeneric<>).LtcIsSubClassOfGeneric(typeof(BaseGeneric<>)), "25");
            Assert.True(typeof(BaseGeneric<>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<>)), "26");
            Assert.True(typeof(BaseGeneric<Class1>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<>)), "27");
            Assert.False(typeof(IBaseGeneric<Class1>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<Class1>)), "28");
            Assert.True(typeof(BaseGeneric2<Class1>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<Class1>)), "29");
            Assert.False(typeof(IBaseGeneric<>).LtcIsSubClassOfGeneric(typeof(BaseGeneric2<>)), "30");
            Assert.True(typeof(BaseGeneric2<>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<>)), "31");
            Assert.True(typeof(BaseGeneric2<Class1>).LtcIsSubClassOfGeneric(typeof(IBaseGeneric<>)), "32");
            Assert.True(typeof(ChildGenericA).LtcIsSubClassOfGeneric(typeof(BaseGenericA<,>)), "33");
            Assert.False(typeof(ChildGenericA).LtcIsSubClassOfGeneric(typeof(WrongBaseGenericA<,>)), "34");
            Assert.True(typeof(ChildGenericA).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<,>)), "35");
            Assert.False(typeof(ChildGenericA).LtcIsSubClassOfGeneric(typeof(IWrongBaseGenericA<,>)), "36");
            Assert.True(typeof(IChildGenericA).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<,>)), "37");
            Assert.False(typeof(IWrongBaseGenericA<,>).LtcIsSubClassOfGeneric(typeof(ChildGenericA2<,>)), "38");
            Assert.True(typeof(ChildGenericA2<,>).LtcIsSubClassOfGeneric(typeof(BaseGenericA<,>)), "39");
            Assert.True(typeof(ChildGenericA2<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(BaseGenericA<,>)), "40");
            Assert.True(typeof(ChildGenericA).LtcIsSubClassOfGeneric(typeof(BaseGenericA<ClassA, ClassB>)), "41");
            Assert.False(typeof(ChildGenericA).LtcIsSubClassOfGeneric(typeof(WrongBaseGenericA<ClassA, ClassB>)), "42");
            Assert.True(typeof(ChildGenericA).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<ClassA, ClassB>)), "43");
            Assert.False(typeof(ChildGenericA).LtcIsSubClassOfGeneric(typeof(IWrongBaseGenericA<ClassA, ClassB>)), "44");
            Assert.True(typeof(IChildGenericA).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<ClassA, ClassB>)), "45");
            Assert.False(typeof(BaseGenericA<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(ChildGenericA2<ClassA, ClassB>)), "46");
            Assert.True(typeof(ChildGenericA2<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(BaseGenericA<ClassA, ClassB>)), "47");
            Assert.False(typeof(ChildGenericA).LtcIsSubClassOfGeneric(typeof(ChildGenericA)), "48");
            Assert.False(typeof(IChildGenericA).LtcIsSubClassOfGeneric(typeof(IChildGenericA)), "49");
            Assert.False(typeof(IBaseGenericA<,>).LtcIsSubClassOfGeneric(typeof(IChildGenericA2<,>)), "50");
            Assert.True(typeof(IChildGenericA2<,>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<,>)), "51");
            Assert.True(typeof(IChildGenericA2<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<,>)), "52");
            Assert.False(typeof(IBaseGenericA<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(IChildGenericA2<ClassA, ClassB>)), "53");
            Assert.True(typeof(IChildGenericA2<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<ClassA, ClassB>)), "54");
            Assert.False(typeof(IBaseGenericA<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(BaseGenericA<ClassA, ClassB>)), "55");
            Assert.True(typeof(BaseGenericA<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<ClassA, ClassB>)), "56");
            Assert.False(typeof(IBaseGenericA<,>).LtcIsSubClassOfGeneric(typeof(BaseGenericA<,>)), "57");
            Assert.True(typeof(BaseGenericA<,>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<,>)), "58");
            Assert.True(typeof(BaseGenericA<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<,>)), "59");
            Assert.False(typeof(IBaseGenericA<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<ClassA, ClassB>)), "60");
            Assert.True(typeof(BaseGenericA2<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<ClassA, ClassB>)), "61");
            Assert.False(typeof(IBaseGenericA<,>).LtcIsSubClassOfGeneric(typeof(BaseGenericA2<,>)), "62");
            Assert.True(typeof(BaseGenericA2<,>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<,>)), "63");
            Assert.True(typeof(BaseGenericA2<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<,>)), "64");
            Assert.False(typeof(BaseGenericA2<ClassB, ClassA>).LtcIsSubClassOfGeneric(typeof(IBaseGenericA<ClassA, ClassB>)), "65");
            Assert.False(typeof(BaseGenericA<ClassB, ClassA>).LtcIsSubClassOfGeneric(typeof(ChildGenericA2<ClassA, ClassB>)), "66");
            Assert.False(typeof(BaseGenericA2<ClassB, ClassA>).LtcIsSubClassOfGeneric(typeof(BaseGenericA<ClassA, ClassB>)), "67");
            Assert.True(typeof(ChildGenericA3<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(BaseGenericB<ClassA, ClassB, ClassC>)), "68");
            Assert.True(typeof(ChildGenericA4<ClassA, ClassB>).LtcIsSubClassOfGeneric(typeof(IBaseGenericB<ClassA, ClassB, ClassC>)), "69");
            Assert.False(typeof(ChildGenericA3<ClassB, ClassA>).LtcIsSubClassOfGeneric(typeof(BaseGenericB<ClassA, ClassB, ClassC>)), "68-2");
            Assert.True(typeof(ChildGenericA3<ClassA, ClassB2>).LtcIsSubClassOfGeneric(typeof(BaseGenericB<ClassA, ClassB, ClassC>)), "68-3");
            Assert.False(typeof(ChildGenericA3<ClassB2, ClassA>).LtcIsSubClassOfGeneric(typeof(BaseGenericB<ClassA, ClassB, ClassC>)), "68-4");
            Assert.False(typeof(ChildGenericA4<ClassB, ClassA>).LtcIsSubClassOfGeneric(typeof(IBaseGenericB<ClassA, ClassB, ClassC>)), "69-2");
            Assert.True(typeof(ChildGenericA4<ClassA, ClassB2>).LtcIsSubClassOfGeneric(typeof(IBaseGenericB<ClassA, ClassB, ClassC>)), "69-3");
            Assert.False(typeof(ChildGenericA4<ClassB2, ClassA>).LtcIsSubClassOfGeneric(typeof(IBaseGenericB<ClassA, ClassB, ClassC>)), "69-4");
            Assert.False(typeof(bool).LtcIsSubClassOfGeneric(typeof(IBaseGenericB<ClassA, ClassB, ClassC>)), "70");
        }
    }


    public class Class1 { }
    public class BaseGeneric<T> : IBaseGeneric<T> { }
    public class BaseGeneric2<T> : IBaseGeneric<T>, IInterfaceBidon { }
    public interface IBaseGeneric<T> { }
    public class ChildGeneric : BaseGeneric<Class1> { }
    public interface IChildGeneric : IBaseGeneric<Class1> { }
    public class ChildGeneric2<Class1> : BaseGeneric<Class1> { }
    public interface IChildGeneric2<Class1> : IBaseGeneric<Class1> { }

    public class WrongBaseGeneric<T> { }
    public interface IWrongBaseGeneric<T> { }

    public interface IInterfaceBidon { }

    public class ClassA { }
    public class ClassB { }
    public class ClassC { }
    public class ClassB2 : ClassB { }
    public class BaseGenericA<T, U> : IBaseGenericA<T, U> { }
    public class BaseGenericB<T, U, V> { }
    public interface IBaseGenericB<ClassA, ClassB, ClassC> { }
    public class BaseGenericA2<T, U> : IBaseGenericA<T, U>, IInterfaceBidonA { }
    public interface IBaseGenericA<T, U> { }
    public class ChildGenericA : BaseGenericA<ClassA, ClassB> { }
    public interface IChildGenericA : IBaseGenericA<ClassA, ClassB> { }
    public class ChildGenericA2<ClassA, ClassB> : BaseGenericA<ClassA, ClassB> { }
    public class ChildGenericA3<ClassA, ClassB> : BaseGenericB<ClassA, ClassB, ClassC> { }
    public class ChildGenericA4<ClassA, ClassB> : IBaseGenericB<ClassA, ClassB, ClassC> { }
    public interface IChildGenericA2<ClassA, ClassB> : IBaseGenericA<ClassA, ClassB> { }

    public class WrongBaseGenericA<T, U> { }
    public interface IWrongBaseGenericA<T, U> { }

    public interface IInterfaceBidonA { }
}
