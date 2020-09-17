using System;

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
		bool recur = false;
		int[] sortedArray = array;
		for (int i = 0; i < array.Length - 1; i++)
		{
			if (sortedArray[i] > sortedArray[i + 1])
			{
				int temp = sortedArray[i];
				sortedArray[i] = sortedArray[i + 1];
				sortedArray[i + 1] = temp;
			}
			recur = true;
		}
		if (recur)
		{
			return sortedArray;
		}
		else
		{
			return sort(array);
		}
	}
}
