namespace Delegat
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var class1 = new Class1();
            var class2 = new Class2();

            class2.ShowHandler = Show;
            class2.ShowHandler(class1.Calc(class2.PowHandler, 2, 3).Invoke(2));
        }

        private static void Show(bool x)
        {
            Console.WriteLine(x);
        }
    }
    public class Class1
    {
        private double powResult;

        public Predicate<double> Calc(Func<double, double, double> powHandler, double x, double y)
        {
            powResult = powHandler(x, y);
            Predicate<double> calc = Result;
            return calc;
        }

        private bool Result(double x)
        {
            return this.powResult % x == 0;
        }
    }

    public class Class2
    {
        public Action<bool> ShowHandler;

        public Func<double, double, double> PowHandler => Pow;

        private double Pow(double x, double y)
        {
            return x * y;
        }
    }
}
