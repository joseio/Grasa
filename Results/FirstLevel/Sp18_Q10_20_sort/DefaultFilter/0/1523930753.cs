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
		int length = array.Length;
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length - i - 1; j++)
			{
				if (array[j] > array[j + 1])
				{
					int holder = array[j + 1];
					array[j + 1] = array[j];
					array[j] = holder;
				}
			}
		}
		return array;
	}
}
