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
		int[] result = array;
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = i; j < array.Length; j++)
			{
				if (result[i] > result[j])
				{
					int temp = result[j];
					result[j] = result[i];
					result[i] = temp;
				}
			}
		}
		return result;
	}
}
