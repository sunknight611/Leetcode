using System.ComponentModel;
using System.IO.Pipes;

namespace 保证文件名唯一
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] { "kaido", "kaido(1)", "kaido", "kaido(1)" };
            Solution.GetFolderNames(names);
            
        }
    }
    //kaido kaido(1) kaido(2) kaido(3) kaido（4）
    public class Solution
    {
        public static string[] GetFolderNames(string[] names)
        {
            string[] ans = new string[names.Length];
            Dictionary<string, int> folder = new Dictionary<string, int>();
            //存储每个字符串第一个匹配的位置
            int[] map = new int[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                if (!folder.ContainsKey(names[i]))
                {
                    folder.Add(names[i], 1);
                    map[i] = -1;
                    Console.WriteLine(names[i]);
                    ans[i] = names[i];
                }
                else
                {
                    //int count = 2;
                    //if (!folder.ContainsKey(names[i] + "(1)"))
                    //{
                    //    folder.Add(names[i] + "(1)", 1);
                    //    Console.WriteLine(names[i] + "(1)");
                    //    ans[cur++] = names[i] + "(1)";
                    //}
                    //else
                    //{
                    //    while (folder.ContainsKey(names[i] + "(" + count.ToString() + ")"))
                    //    {
                    //        count++;
                    //    }
                    //    folder.Add(names[i] + "(" + count.ToString() + ")", 1);
                    //    Console.WriteLine(names[i] + "(" + count.ToString() + ")");
                    //    ans[cur++] = names[i] + "(" + count.ToString() + ")";
                    //}

                    int index = folder[names[i]];
                    while (folder.ContainsKey(names[i] + "(" + index.ToString() + ")"))
                    {
                        index++;
                    }
                    folder[names[i]] = index + 1;
                    folder.Add(names[i] + "(" + index.ToString() + ")",1);
                    ans[i] = names[i] + "(" + index.ToString() + ")";
                    Console.WriteLine(names[i] + "(" + index.ToString() + ")");
                }
            }
            return ans;
        }
    }
}