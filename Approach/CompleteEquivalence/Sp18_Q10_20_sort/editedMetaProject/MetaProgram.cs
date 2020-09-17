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

        public class Program
        {

            /// <summary>Sort the array in ascending order.</summary>
            /// <remarks>
            /// Sort the array in ascending order.
            /// You may return either a reference to a new array or to the passed array.
            /// Note that you may not use java.util.Arrays.
            /// </remarks>

	public static int[] sort(int[] arraya)
	{
		if (arraya.Length < 2)
		{
			return arraya;
		}
		int[] array = arraya;
		while (isSorted(array) == false)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] > array[i + 1])
				{
					int temp = array[i];
					array[i] = array[i + 1];
					array[i + 1] = temp;
				}
			}
		}
		return array;
	}































	public static int[] sortSolution(int[] array)
	{
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i - 1] > array[i])
			{
				int temp = array[i - 1];
				array[i - 1] = array[i];
				array[i] = temp;
			}
		}
		for (int i_1 = 1; i_1 < array.Length; i_1++)
		{
			if (array[i_1 - 1] > array[i_1])
			{
				sort(array);
			}
		}
		return array;
	}































            public static int[] sortSolutionForReal(int[] array)
            {
                bool isSorted = false;
                while (!isSorted)
                {
                    isSorted = true;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            int tmp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = tmp;
                            isSorted = false;
                        }
                    }
                }
                return array;
            }


            /*public static int[] Copy(int[] original)
            {
                int[] copy = new int[original.Length];

                for (int i = 0; i < original.Length; i++)
                {
                    copy[i] = original[i];
                }
                return copy;
            }*/


            public static bool isEquals(int[] first, int[]second)
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
        }







        [PexMethod]
        public static void Check([PexAssumeNotNull]int[] arr, [PexAssumeNotNull]int[] solArr)
        {
            //int[] solArr = Program.Copy(arr);
            //04/11/19, Below is replacement for Copy(), as not to cause issues for Pex
            PexAssume.IsTrue(Program.equals(arr, solArr));

            bool firstIndex = false;
            bool secondIndex = false;
            int[] firstArr = new int[arr.Length];
            int[] secondArr = new int[solArr.Length];
            try
            {
                firstArr = Program.sort(arr);
            }
            catch (IndexOutOfRangeException e)
            {
                firstIndex = true;
            }

            try
            {
                secondArr = Program.sortSolution(solArr);
            }
            catch (IndexOutOfRangeException e)
            {
                secondIndex = true;
            }
            bool passingCondition = ((firstIndex == secondIndex && firstIndex == true) || (firstIndex == secondIndex && firstIndex == false && Program.isEquals(firstArr, secondArr)));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception();
        }
    }
}
