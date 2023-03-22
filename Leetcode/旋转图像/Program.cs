namespace 旋转图像
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[2][];
            matrix[0] = new int[2] { 1, 2 };
            matrix[1] = new int[2] { 3, 4 };

            swap(matrix[0][0], matrix[1][1]);
            Console.WriteLine("{0} {1}", matrix[0][0].ToString(), matrix[1][1].ToString());

        }

        public static void swap(int nums1, int nums2)
        {
            int temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }
    }
}