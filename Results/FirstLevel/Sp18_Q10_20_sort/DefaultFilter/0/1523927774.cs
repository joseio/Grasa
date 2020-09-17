using System;

public class Program
{
	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// Note that you may not use java.util.Arrays.
	/// </remarks>
	public static int[] sort(int[] input)
	{
		int[] array = new int[input.Length];
		for (int i = 0; i < input.Length; i++)
		{
			array[i] = input[i];
		}
		for (int c = 0; c < array.Length; c++)
		{
			for (int d = 0; d < (array.Length - c - 1); d++)
			{
				if (array[d + 1] < array[d])
				{
					int temp = array[d + 1];
					array[d + 1] = array[d];
					array[d] = temp;
				}
			}
		}
		return array;
	}
}
