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
		for (int k = 0; k < array.Length - 1; k++)
		{
			if (array[k] > array[k + 1])
			{
				int temp = array[k];
				array[k] = array[k + 1];
				array[k + 1] = temp;
				sorted = false;
			}
		}
		if (sorted == false)
		{
			return sort(array);
		}
		return array;
	}
}
