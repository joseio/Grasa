using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		bool flag = true;
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] > array[i - 1])
			{
				flag = false;
			}
			if (flag == false)
			{
				return false;
			}
		}
		return flag;
	}
}
