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
		int[] result = new int[array.Length];
		for (int n = 0; n < array.Length; n++)
		{
			result[n] = array[n];
		}
		int temp = 0;
		for (int i = 0; i < result.Length; i++)
		{
			for (int j = i; j > 0; j--)
			{
				if (result[j] < result[j - 1])
				{
					temp = result[j];
					result[j] = result[j - 1];
					result[j - 1] = temp;
				}
			}
		}
		return result;
	}
}
