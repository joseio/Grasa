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

public class Partitioner
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








        






[PexMethod]
        public static void Check([PexAssumeNotNull] int[] arr1, [PexAssumeNotNull] int[] arr2)
        {
            PexAssume.AreNotSame(arr1, arr2); //Don't refer to same mem locations
            PexAssume.IsTrue(isEquals(arr1, arr2)); //Deep check

            bool ans1Except = false, ans2Except = false;
            int ans1 = -100, ans2 = -100;

            try
            {
                ans1 = Partitioner.partition(arr1);
            }
            catch (IndexOutOfRangeException)
            {
                ans1Except = true;
            }

            try
            {
                ans2 = PartitionerSolution.partition(arr2);
            }
            catch (IndexOutOfRangeException)
            {
                ans2Except = true;
            }

            bool passingCondition = ((ans1Except == ans2Except && ans1Except == true) || (ans1Except == ans2Except && ans1Except == false && ans1 == ans2));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception();
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


        public class PartitionerSolution
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
