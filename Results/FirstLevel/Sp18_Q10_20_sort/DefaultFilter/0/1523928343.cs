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
		int temp;
		for (int i = 0; i < array.Length; i++)
		{
			for (int n = 0; n < array.Length - 1; n++)
			{
				if (array[n + 1] < array[n])
				{
					temp = array[n + 1];
					array[n + 1] = array[n];
					array[n] = temp;
				}
			}
		}
		return array;
	}
}
