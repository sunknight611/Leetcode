namespace 面试
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public delegate void testDelegate();

    public interface ITest
    {
        public object A { get; set; }

        public void test();

        event testDelegate testDelegate;

        public Test this[int i] { get; set; } 

    }

    public class Test : ITest
    {
        public Test[] arr = new Test[10];
        public Test this[int i] { get => arr[i]; set => arr[i] = value; }

        public object A { get; set; } = new object();

        public event testDelegate testDelegate;

        public void test()
        {
            Console.WriteLine();
        }
    }
}