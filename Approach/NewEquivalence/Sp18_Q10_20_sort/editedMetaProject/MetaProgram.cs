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

            public static int[] sort(int[] array)
	{
		bool sorted = false;
		while (!sorted)
		{
			sorted = true;
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] > array[i + 1])
				{
					int temp = array[i];
					array[i] = array[i + 1];
					array[i + 1] = temp;
					sorted = true;
				}
			}
		}
		return array;
	}































            public static int[] sortSolution(int[] array)
	{
		bool sortSolutioned = false;
		while (!sortSolutioned)
		{
			sortSolutioned = true;
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] > array[i + 1])
				{
					int temp = array[i];
					array[i] = array[i + 1];
					array[i + 1] = temp;
					sortSolutioned = true;
				}
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


            public static int[] Copy(int[] original)
            {
                int[] copy = new int[original.Length];

                for (int i = 0; i < original.Length; i++)
                {
                    copy[i] = original[i];
                }
                return copy;
            }

            public static bool isEquals(int[] first, int[] second)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] != second[i])
                        return false;
                }
                return true;

            }

        }







[PexMethod]
        public static void Check([PexAssumeNotNull]int[] arr, Boolean b)
        {
            int[] solArr = Program.Copy(arr);
            int[] realSolArr = Program.Copy(arr);

            bool firstIndex = false;
            bool secondIndex = false;
            int[] firstArr = new int[arr.Length];
            int[] secondArr = new int[arr.Length];
            int[] thirdArr = new int[arr.Length];

            try
            {
                firstArr = Program.sort(arr);
                //firstArr = Program.sortSolution(arr);
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

            try
            {
                thirdArr = Program.sortSolutionForReal(realSolArr);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("sortSolutionForReal got index out of range!");
            }

            bool passingCondition = ((firstIndex == secondIndex && firstIndex == true) || (firstIndex == secondIndex && firstIndex == false && Program.isEquals(firstArr, secondArr)));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception("Failed test: Reference solution not equal to student submission.");

            if (passingCondition)
            {
                if (b)
                {
                    if (Program.isEquals(thirdArr, firstArr))
                        if (!Program.isEquals(secondArr, firstArr))
                            throw new Exception();
                }
                else
                {
                    if (Program.isEquals(thirdArr, secondArr))
                        if (!Program.isEquals(secondArr, firstArr))
                            throw new Exception();
                }
            }
        }
    }
}
