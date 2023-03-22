namespace 寻找两个正序数组的中位数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3,4 };
            solution.FindMedianSortedArrays(nums1, nums2);
        }
    }

    class Solution
    {
        //寻找两个正序数组中第k个数
        //public static double getKelements(int[] nums1, int[] nums2,int k)
        //{
        //    int index1 = 0,index2 = 0;
        //    int m = nums1.Length;
        //    int n = nums2.Length;
        //    while(true)
        //    {
        //        //一个数组若以全部排除，则返回剩下数组的第k个元素
        //        if(index1 == m)
        //        {
        //            return nums2[index2 + k - 1];
        //        }

        //        if(index2 == n)
        //        {
        //            return nums1[index1 + k - 1];
        //        }

        //        //如果k=1则返回两个数组中较小的数
        //        if(k == 1)
        //        {
        //            return Math.Min(nums1[index1], nums2[index2]);
        //        }

        //        //找到每个数组第k/2个位子，若大于数组长度，则选取数组最后一个位置

        //        int newIndex1 = Math.Min(index1 + k / 2 - 1,m - 1);
        //        int newIndex2 = Math.Min(index2 + k / 2 - 1,n - 1);
        //        //若nums1[k / 2 - 1] < nums2[k / 2-1]说明至多有k-2个数比nums[k/2 - 1]小，则
        //        //排除nums1前k / 2- 1 个数
        //        int pivot1 = nums1[newIndex1];
        //        int pivot2 = nums2[newIndex2];


        //        if(pivot1 <= pivot2) {
        //            k -= newIndex1 - index1 + 1;
        //            index1 = newIndex1 + 1;
        //        }
        //        else
        //        {
        //            k -= newIndex2 - index2 + 1;
        //            index2 = newIndex2 + 1;
        //        }
        //    }
        //}

        //public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        //{
        //    int totalLength = nums1.Length + nums2.Length;
        //    //两个数组总长为奇数，返回第k个数
        //    if(totalLength % 2 == 1)
        //    {
        //        return getKelements(nums1,nums2,(totalLength+1) /2);
        //    }//否则返回 （num[k]+num[k+1]）/2
        //    else
        //    {
        //        return (getKelements(nums1, nums2, totalLength / 2) + getKelements(nums1, nums2, totalLength + 1 / 2 + 1)) / 2.0;
        //    }

        //}

        public int getKelements(int[] nums1, int[] nums2, int k)
        {
            int index1 = 0, index2 = 0;
            int m = nums1.Length;
            int n = nums2.Length;
            while (true)
            {
                //如果nums1为空，则返回nums2第k个元素
                if (index1 == m) return nums2[index2 + k - 1];

                if (index2 == n) return nums1[index1 + k - 1];

                //如果k为1，则返回nums1[0]和nums2[0]中较小的那个
                if (k == 1) return Math.Min(nums1[index1], nums2[index2]);

                //取nums1和nums2第k/2个元素
                //并且要保证index + k/2不越界
                int pivot1 = Math.Min(index1 + k / 2 - 1, m - 1);
                int pivot2 = Math.Min(index2 + k / 2 - 1, n - 1);
                int pivotNum1 = nums1[pivot1];
                int pivotNum2 = nums2[pivot2];
                //如果pivot1 < pivot2说明有至多有k - 2个元素比pivot1小，所有pivot1不可能是第k个数,因此可以排除
                //pivot1的k/2个数

                if (pivotNum1 <= pivotNum2)
                {
                    k -= pivot1 - index1 + 1;
                    index1 = pivot1 + 1;
                }
                else
                {
                    k -= pivot2 - index2 + 1;
                    index2 = pivot2 + 1;
                }
            }
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int totalLength = nums1.Length + nums2.Length;
            //两个数组总长为奇数，返回第k个数
            if (totalLength % 2 == 1)
            {
                return getKelements(nums1, nums2, (totalLength + 1) / 2);
            }//否则返回 （num[k]+num[k+1]）/2
            else
            {
                return (getKelements(nums1, nums2, totalLength / 2) + getKelements(nums1, nums2, totalLength/2 + 1)) / 2.0;
            }
        }
    }
}