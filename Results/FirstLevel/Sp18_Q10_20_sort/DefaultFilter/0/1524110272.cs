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
		int key;
		int temp;
		for (int i = 1; i < result.Length; i++)
		{
			key = result[i];
			for (int j = i - 1; j >= 0; j--)
			{
				if (key < result[j])
				{
					temp = result[j];
					result[j] = key;
					result[j + 1] = temp;
				}
			}
		}
		return array;
	}
}
