namespace 课程表
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] pre = new int[4][] { new int[] { 1, 4 }, new int[] { 2,4},new int[] { 3, 1 },new int[] { 3, 2 } };
            var s = new Solution();
            s.CanFinish(5,pre);
        }
    }

    public class Solution
    {
        //判断是否存在在环
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //存储每条边的情况,键为边的起点，即前置课程，值为边的终点
            Dictionary<int, List<int>> edge = new Dictionary<int, List<int>>();
            int[] indeg = new int[numCourses];
            //队列存储拓扑排序(当前可以修的课程)
            Queue<int> queue = new Queue<int>();
            //记载已修的课程数
            int res = 0;
            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                if (!edge.ContainsKey(prerequisites[i][1]))
                {
                    //增加该边
                    edge.Add(prerequisites[i][1], new List<int>() { prerequisites[i][0] });
                }
                else
                {
                    edge[prerequisites[i][1]].Add(prerequisites[i][0]);
                }
                //起点的入度加一
                indeg[prerequisites[i][0]]++;
            }
            for (int i = 0; i < numCourses; i++)
            {
                if (indeg[i] == 0)
                {
                    //入度为0的课程为可修课程，加入队列
                    queue.Enqueue(i);
                   // break;
                }
            }
            //队列中还存在可修课程
            while (queue.Count > 0)
            {
                //取出一门课程
                int cur = queue.Dequeue();
                res++;
                for (int i = 0; i < edge[cur].Count; i++)
                {
                    //该边所有相连的顶点入度减1
                    indeg[edge[cur][i]]--;
                    //若有节点的入度为0,则加入队列
                    if (indeg[edge[cur][i]] == 0)
                        queue.Enqueue(edge[cur][i]);
                }
            }
            if (res == numCourses) return true;
            return false;
        }
    }
}