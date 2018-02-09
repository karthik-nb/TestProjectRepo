using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalTestApp
{
    interface ITestInterface
    {
        void Print(int i);
    }

    public class BaseClass
    {
        public virtual void Print(int i)
        {
            Console.WriteLine("Baseclass PRINT");
        }

        /***
         * 1) We cannot directly delcare a sealed method inside a class (uncomment below method to see)
         *    CS compiler error: 'BaseClass.TestSeal()' cannot be sealed because it is not an override
         * 
         * 2) We cannot override the below method as it is actually not overriding any parent.
         *    If 'override' method is added, CS compiler will throw below error.
         *    'LocalTestApp.BaseClass.TestSeal()': no suitable method found to override
         ***/

        //public sealed void TestSeal()
        //{
        //    Console.WriteLine("Sealed method");
        //}
    }

    //When both a derived class inherits both interface & baseclass
    //then we dont need to implement 'interface' here as far as 'baseclass' has the implementation
    //Because, thats the concept of inheritance. Derived will have both it's own properties & base class implementations
    public class FirstDerivedClass : BaseClass, ITestInterface
    {
        public override void Print(int i)
        {
            Console.WriteLine("FirstDerivedClass PRINT");
        }
        
        //Uncomment below to see how 'new' method implementation works in derived class
        //public void Print(double i)
        //{
        //    Console.WriteLine("Calling base");
        //    base.Print(1);
        //    Console.WriteLine("FirstDerivedClass PRINT");
        //}
    }

    public class SecondDerivedClass : FirstDerivedClass
    {
        //We cannot override a 'sealed' method in derived.
        //However, we can write a new implementation
        public override void Print(int i)
        {
            base.Print(i);
            Console.WriteLine("SecondDerivedClass PRINT");
        }
    }

    public class ExplicitImpClass : ITestInterface
    {
        void ITestInterface.Print(int i)
        {
            Console.WriteLine("Explicit Imp Class");
        }
    }

    public class DerivedExpImpClass : ExplicitImpClass, ITestInterface
    {
        //Only way to call base class explicitly implemented method is to implement like 'new' method
        //And remove 'interface' reference from inheritance chain, else 'Stack overflow' error will be thrown 
        // because method is called recursively
        //Check the next class for implementation
        public void Print(int i)
        {
            //Below code will throw error
            //((ITestInterface)base).Print(1);

            //((ITestInterface)this).Print(1);
            Console.WriteLine("Dervied Exp Imp Class");
        }

        //void ITestInterface.Print(int i)
        //{
        //    //Below call is recrusive. So 'Stack OverFlow' exception will throw.
        //    //((ITestInterface)this).Print(1);

        //    Console.WriteLine("Dervied Exp Imp Class");
        //}
    }

    public class BaseClass2 : ITestInterface
    {
        public void Print(int i)
        {
            Console.WriteLine("Base Class 2 Print method");
        }
    }

    public class DerivedClass2 : BaseClass2
    {
        public new void Print(int i)
        {
            base.Print(i);

            ((ITestInterface)this).Print(i);
        }
    }
}