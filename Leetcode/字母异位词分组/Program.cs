namespace 字母异位词分组
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Solution
    {
        Dictionary<string, IList<string>> lookup = new Dictionary<string, IList<string>>();
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> ans = new List<IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                LookUp(strs[i]);
            }

            foreach (var item in lookup)
                ans.Add(item.Value);
                

            return ans;
        }

        public void LookUp(string str)
        {
            int n = str.Length;
            int[] nums = new int[n];
            String key = "";
            for (int i = 0; i < n; i++)
                nums[i] = str[i] - '0';

            Array.Sort(nums);

            for (int i = 0; i < n; i++)
                key += nums[i].ToString() + '-';
            if (!lookup.ContainsKey(key))
            {
                lookup.Add(key, new List<string>() { str });
            }
            else
            {
                lookup[key].Add(str);
            }
        }

    }
}