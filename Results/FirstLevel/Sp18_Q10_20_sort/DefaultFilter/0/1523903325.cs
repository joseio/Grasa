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
		int count = 0;
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] < array[i - 1])
			{
				int temp = array[i];
				array[i] = array[i - 1];
				array[i - 1] = temp;
				count++;
			}
		}
		if (count != 0)
		{
			return sort(array);
		}
		return array;
	}
}
