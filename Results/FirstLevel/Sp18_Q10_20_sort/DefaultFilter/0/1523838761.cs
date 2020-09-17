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
		bool sorted = true;
		int temp = 0;
		int[] toSort = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			toSort[i] = array[i];
		}
		for (int i_1 = 1; i_1 < array.Length; i_1++)
		{
			if (toSort[i_1] < toSort[i_1 - 1])
			{
				temp = toSort[i_1];
				toSort[i_1] = toSort[i_1 - 1];
				toSort[i_1 - 1] = temp;
				sorted = false;
			}
		}
		if (sorted)
		{
			return toSort;
		}
		return sort(toSort);
	}
}
