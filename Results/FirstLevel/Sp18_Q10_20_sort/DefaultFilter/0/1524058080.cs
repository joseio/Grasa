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
		bool sorted = false;
		while (!sorted)
		{
			sorted = true;
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] > array[i + 1])
				{
					int tmp = array[i];
					array[i] = array[i + 1];
					array[i + 1] = tmp;
					sorted = false;
				}
			}
		}
		return array;
	}
}
