namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //List<int> list = new List<int>();
            //IList<IList<int>> ans = new List<IList<int>>();
            //test(ans, list);
            List<int> nums = new List<int>() {1,2,3,4,5,6};
            var ans = nums.Take<int>(2);
            foreach (int x in ans)
            {
                Console.WriteLine(x);
            }
        }

        static void test(IList<IList<int>> ans,List<int> list)
        {
            for(int i = 0;i < 4; i++)
            {
                list.Add(i);
            }

            ans.Add(list);
        }
    }
}