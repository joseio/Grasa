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
		int[] newArray = new int[array.Length];
		for (int i = 0; i < array.Length - 1; i++)
		{
			for (int j = i + 1; j < array.Length; j++)
			{
				if (array[i] > array[j])
				{
					int temp = array[i];
					array[i] = array[j];
					array[j] = temp;
				}
			}
		}
		return array;
	}
}
