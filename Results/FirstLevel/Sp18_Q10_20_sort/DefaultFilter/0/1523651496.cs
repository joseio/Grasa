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
		for (int i = 0; i < result.Length; i++)
		{
			int swap = result[0];
			for (int j = 0; j < result.Length - i - 1; j++)
			{
				swap = result[j];
				if (swap > result[j + 1])
				{
					int tmp = result[j];
					result[j] = result[j + 1];
					result[j + 1] = tmp;
				}
			}
		}
		return result;
	}
}
