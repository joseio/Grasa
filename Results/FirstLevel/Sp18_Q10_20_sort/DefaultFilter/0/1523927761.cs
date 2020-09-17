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
		for (int i = 0; i < array.Length; i++)
		{
			for (int l = 0; l < array.Length - i - 1; l++)
			{
				if (array[l] > array[l + 1])
				{
					int temp = array[l];
					array[l] = array[l + 1];
					array[l + 1] = temp;
				}
			}
		}
		return array;
	}
}
