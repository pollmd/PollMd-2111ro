
namespace LambdaNDelegates
{
    public class Program
    {
        Func<int, int, int> patratxLambda = (x, y) => x * y;

        Func<int, int, int> patratxLambda2 = (x, y) => { return x * y; };

        //Action<int, int> afisareLambda = (x, a) => Console.WriteLine(x);
        delegate double OperatieAritmetica(double x, double y);

        static void Main(string[] args)
        {
            var calc = new Calculator();
            OperatieAritmetica del = new OperatieAritmetica(calc.Add);
            Console.WriteLine(del(10, 4));

            del = new OperatieAritmetica(calc.Sub);
            Console.WriteLine(del(10, 4));

            del = new OperatieAritmetica(calc.Mult);
            Console.WriteLine(del(10, 4));

            del = new OperatieAritmetica(calc.Div);
            Console.WriteLine(del(10, 4));
        }
    }
}





