using System.Text.RegularExpressions;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using System.Diagnostics;

namespace MetaProject
{
    [PexClass(typeof(MetaProgram))]
    public partial class MetaProgram
    {

// sezouj3-2018_Fall_E2_130_1-1544413397000 （multi-cluster）
public class Partitioner
{
    public static int partition(int[] values)
    {
        if (values == null || values.Length == 0)
        {
            return 0;
        }
        int pivot = values[0];
        int[] newarr = values;
        int i = 0;
        int j = values.Length - 1;
        for (int k = 1; k < newarr.Length; k++)
        {
            if (newarr[k] < pivot)
            {
                values[i] = newarr[k];
                i++;
            }
            else if (newarr[k] >= pivot)
            {
                values[j] = newarr[k];
                j--;
            }
            if (i >= j)
            {
                break;
            }
        }
        Console.WriteLine(pivot);
        foreach (int k in values)
        {
            Console.Write(k + " ");
        }
        Console.WriteLine();
        values[i] = pivot;
        return i;
    }
}






        [PexMethod]
        public static void Check([PexAssumeNotNull] int[] arr1, [PexAssumeNotNull] int[] arr2,
            [PexAssumeNotNull] int[] arr3, [PexAssumeNotNull] int[] solnArr)
        {
            PexAssume.AreDistinctReferences(new Object[] {arr1, arr2, arr3, solnArr}); //Don't refer to same mem locations
            PexAssume.IsTrue(isEquals(arr1, arr2)); //Deep check
            PexAssume.IsTrue(isEquals(arr2, arr3));
            PexAssume.IsTrue(isEquals(arr3, solnArr));



            bool ans1Except = false, ans2Except = false, ans3Except = false, solnExcept = false;
            int ans1 = -100, ans2 = -100, ans3 = -100, solnAns = -100, count = 0;

            try
            {
                ans1 = Partitioner.partition(arr1);
            }
            catch (IndexOutOfRangeException)
            {
                ans1Except = true;
            }

            /*
            try
            {
                ans2 = PartitionerSub2.partition(arr2);
            }
            catch (IndexOutOfRangeException)
            {
                ans2Except = true;
            }

            try
            {
                ans3 = PartitionerSub3.partition(arr3);
            }
            catch (IndexOutOfRangeException)
            {
                ans3Except = true;
            }
             * */

            try
            {
                solnAns = PartitionerSolutionForReal.partition(solnArr);
            }
            catch (IndexOutOfRangeException)
            {
                solnExcept = true;
            }


            bool passingCondition = ((ans1Except == solnExcept && ans1Except == true) || (ans1Except == solnExcept && ans1Except == false && ans1 == solnAns));
            bool failingCondition = !passingCondition;
            if (failingCondition)
            {
                count++;
                Debug.WriteLine("sub1 not equal to instructor soln");
            }

            /*
            bool passingCondition2 = ((ans2Except == solnExcept && ans2Except == true) || (ans2Except == solnExcept && ans2Except == false && ans2 == solnAns));
            bool failingCondition2 = !passingCondition2;
            if (failingCondition2)
            {
                count++;
                Debug.WriteLine("sub2 not equal to instructor soln");
            }

            bool passingCondition3 = ((ans3Except == solnExcept && ans3Except == true) || (ans3Except == solnExcept && ans3Except == false && ans3 == solnAns));
            bool failingCondition3 = !passingCondition3;
            if (failingCondition3)
            {
                count++;
                Debug.WriteLine("sub3 not equal to instructor soln");
            }
             * */


            PexObserve.ValueForViewing("count", count);
            PexAssert.IsTrue(count <= 3);
        }


        public static bool isEquals(int[] first, int[] second)
        {
            //If either is null, return false
            if (first == null || second == null)
                return false;
            //If sizes not the same, return false
            if (first.Length != second.Length)
                return false;
            //If both empty, return true
            if (first.Length == 0 && second.Length == 0)
                return true;

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                    return false;
            }
            return true;
        }


        // qvgr3-2018_Fall_E2_130_1-1544488089000 (single cluster)
        public class PartitionerSub2
        {
            public static int partition(int[] values)
            {
                if (values == null || values.Length == 0)
                {
                    return 0;
                }
                if (values.Length < 3)
                {
                    int piv = values[0];
                    int count = 0;
                    foreach (int value in values)
                    {
                        if (value < piv)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine(values.Length);
                    return count;
                }
                Console.WriteLine(values.Length);
                for (int i = 1; i < values.Length; i++)
                {
                    values[i] = 999999;
                }
                return 0;
            }
        }

        // wffsq4-2018_Fall_E2_130_1-1544481385000 (single cluster)
        public class PartitionerSub3
        {
            public static int partition(int[] values)
            {
                if (values == null || values.Length == 0)
                {
                    return 0;
                }
                if (values.Length == 1)
                {
                    return 0;
                }
                if (values.Length == 2 && values[0] < values[1])
                {
                    return 0;
                }
                else if (values.Length == 2)
                {
                    return 1;
                }
                int index = 1;
                for (int i = 1; i < values.Length; i++)
                {
                    if (values[i] < values[0])
                    {
                        if (i != index)
                        {
                            int temp = values[i];
                            values[i] = values[index];
                            values[index] = temp;
                        }
                        index++;
                    }
                }
                index--;
                Console.WriteLine(values[0]);
                int temp_1 = values[0];
                values[0] = values[index];
                values[index] = temp_1;
                for (int i = 0; i < values.Length; i++)
                {
                    Console.WriteLine(values[i]);
                    if (i == index - 1)
                    {
                        Console.Write("index   ");
                    }
                }
                return index;
            }
        }





        public class PartitionerSolutionForReal
        {
            public static int partition(int[] values)
            {
                if (values == null || values.Length == 0)
                {
                    return 0;
                }
                int start = 0;
                int temp = 0;
                int pivotPosition = 0;
                int pivot = values[pivotPosition];
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] < pivot)
                    {
                        pivotPosition++;
                        temp = values[pivotPosition];
                        values[pivotPosition] = values[i];
                        values[i] = temp;
                    }
                }
                temp = values[pivotPosition];
                values[pivotPosition] = pivot;
                values[start] = temp;
                return pivotPosition;
            }
        }
    }
}
