using System;

public class Program
{
	public static int getSmallestIndex(int[] array, int lo, int hi)
	{
		int smallest = array[lo];
		int returnIndex = lo;
		for (int i = lo; i <= hi; i++)
		{
			if (array[i] < smallest)
			{
				smallest = array[i];
				returnIndex = i;
			}
		}
		return returnIndex;
	}

	public static int[] swap(int[] array, int a, int b)
	{
		int[] returnArr = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			returnArr[i] = array[i];
		}
		int temp = returnArr[a];
		returnArr[a] = returnArr[b];
		returnArr[b] = temp;
		return returnArr;
	}

	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// Note that you may not use java.util.Arrays.
	/// </remarks>
	public static int[] sort(int[] array)
	{
		int[] returnArr = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			returnArr[i] = array[i];
		}
		for (int i_1 = 0; i_1 < array.Length; i_1++)
		{
			int index = getSmallestIndex(returnArr, i_1, array.Length - 1);
			returnArr = swap(returnArr, i_1, index);
		}
		return returnArr;
	}
}
