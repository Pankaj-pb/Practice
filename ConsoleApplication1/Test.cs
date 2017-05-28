using System;

namespace ConsoleApplication1
{
    public interface I1
    {
        void Add();
    }
    public interface I2
    {
        void Add();
    }
    public class Test : I1, I2
    {
        void I1.Add()
        {
            Console.WriteLine("interface I1 Add method Implemented");
        }
        void I2.Add()
        {
            Console.WriteLine("Interface I2 add method implemented");
        }
    }

    public interface IMyInterface
    {
        void Function1();
        void Function2();
        void Function3();
        void Function4();
    }

    public abstract class Base : IMyInterface
    {
        public void Function1()
        {
            throw new NotImplementedException();
        }

        public void Function2()
        {
            throw new NotImplementedException();
        }

        public abstract void Function3();


        public abstract void Function4();

    }
    public class Derived : Base
    {
        public override void Function3()
        {
            throw new NotImplementedException();
        }

        public override void Function4()
        {
            throw new NotImplementedException();
        }

    }
}
