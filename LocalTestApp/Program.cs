using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalTestApp
{
    class Program
    {
        int i;
        public static void Main(string[] args)
        {
            #region Test conditions - commented

            //string timeoutVal = Console.ReadLine();
            //MathFuncTest(Convert.ToInt32(timeoutVal));            

            //int i = 10;
            //decimal j = (decimal)i;
            //Console.WriteLine(j);

            //EventEligibleTest2();
            //EventEligibleTest();

            //try
            //{
            //    ExceptionTest();
            //}
            //catch
            //{
            //    Console.WriteLine("Exception occured");
            //}

            ////int i = 100;
            //string i = "Karthik";
            //DynamicTest(i);

            //LinqTestMethods();

            #endregion

            InheritanceTest();
            Program pg = new Program();
            Console.WriteLine(pg.i);

            Console.ReadKey();
        }

        #region Event test
        private static void EventEligibleTest()
        {
            int start = DateTime.Now.Millisecond;

            StringTest("ONLDVRT");
            StringTest("ONLDVRT.active");
            StringTest("ONLDVRT.inactive");

            StringTest("XSTP");
            StringTest("XSTP.active");
            StringTest("XSTP.inactive");
            StringTest("XSTP.ORIG");
            StringTest("XSTP.POST");
            StringTest("XSTP.PRE");

            StringTest("NSTP");
            StringTest("NSTP.active");
            StringTest("NSTP.inactive");
            StringTest("NSTPER");
            StringTest("NSTPER.active");
            StringTest("NSTPER.inactive");
            StringTest("NSTPRS");
            StringTest("NSTPRS.active");
            StringTest("NSTPRS.inactive");

            StringTest("DVRT");
            StringTest("DVRT.active");
            StringTest("DVRT.inactive");
            Console.WriteLine("Total time - {0}", DateTime.Now.Millisecond - start);
        }

        private static void EventEligibleTest2()
        {
            int start = DateTime.Now.Millisecond;

            StringTest2("ONLDVRT");
            StringTest2("ONLDVRT.active");
            StringTest2("ONLDVRT.inactive");

            StringTest("XSTP");
            StringTest2("XSTP.active");
            StringTest2("XSTP.inactive");
            StringTest2("XSTP.ORIG");
            StringTest2("XSTP.POST");
            StringTest2("XSTP.PRE");

            StringTest2("NSTP");
            StringTest2("NSTP.active");
            StringTest2("NSTP.inactive");
            StringTest2("NSTPER");
            StringTest2("NSTPER.active");
            StringTest2("NSTPER.inactive");
            StringTest2("NSTPRS");
            StringTest2("NSTPRS.active");
            StringTest2("NSTPRS.inactive");

            StringTest2("DVRT");
            StringTest2("DVRT.active");
            StringTest2("DVRT.inactive");
            Console.WriteLine("Total time - {0}", DateTime.Now.Millisecond - start);
        }
        #endregion Event test

        #region String test
        private static void StringTest(string inputString)
        {            
            List<string> excludeList = new List<string>() { "DVRT", "NSTP", "XSTP" };

            foreach (var excludeItem in excludeList)
            {
                if (inputString.Contains(excludeItem))
                    Console.WriteLine("{0} event not allowed", inputString);
            }
        }

        private static void StringTest2(string inputString)
        {
            if (inputString.Contains("DVRT") || inputString.Contains("NSTP") || inputString.Contains("XSTP"))
                Console.WriteLine("{0} event not allowed", inputString);
        }
        #endregion String test

        private static void InheritanceTest()
        {
            //FirstDerivedClass sdc = new SecondDerivedClass();
            //sdc.Print(1);
            //((BaseClass)sdc).Print(1);
            //((FirstDerivedClass)sdc).Print(1);

            //ExplicitImpClass exClass = new ExplicitImpClass();
            //((ITestInterface)exClass).Print(10);
            //DerivedExpImpClass derivedExpClass = new DerivedExpImpClass();
            //((ITestInterface)derivedExpClass).Print(10);
            //derivedExpClass.Print(10);

            DerivedClass2 dc = new DerivedClass2();
            dc.Print(5);
        }

        private static void MathFuncTest(int paxLength)
        {
            //Console.WriteLine("Enter Pax Length::");
            int timeoutVal = 1;

            Console.WriteLine((Math.Ceiling((decimal)paxLength / 10)) * timeoutVal);
        }

        private static void ExceptionTest()
        {
            try
            {
                int i = 1, j=0;
                var z = i / j;
            }
            catch
            {
                Console.WriteLine("Catch executed");
                throw;
            }
            finally
            {
                Console.WriteLine("Finally executed");
            }
        }

        private static void DynamicTest(dynamic obj)
        {
            Console.WriteLine(obj.ToString());
        }        

        private static void LinqTestMethods()
        {
            LinqTest linqTest = new LinqTest();
            linqTest.ListOfEmployees();
            linqTest.GetTopPaidEmployees(3);
            linqTest.GetTopPaidEmployeesByCity(1);
            linqTest.AggregateTest();
        }
    }
}
