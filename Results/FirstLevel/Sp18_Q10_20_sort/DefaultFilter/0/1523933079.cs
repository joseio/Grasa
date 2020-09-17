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
		if (array == null)
		{
			return null;
		}
		if (array.Length == 0)
		{
			return array;
		}
		bool unsorted = true;
		while (unsorted)
		{
			unsorted = false;
			for (int i = 0; i < array.Length - 1; i++)
			{
				int temp = array[i];
				int temper = array[i + 1];
				if (temp > temper)
				{
					array[i + 1] = temp;
					array[i] = temper;
					unsorted = true;
				}
			}
		}
		return array;
	}
}
