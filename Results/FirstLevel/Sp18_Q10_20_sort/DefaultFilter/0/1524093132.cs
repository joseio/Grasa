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
		int[] output = array;
		for (int i = 0; i < array.Length - 1; i++)
		{
			for (int j = 0; j < array.Length - i - 1; j++)
			{
				if (output[j] > output[j + 1])
				{
					int temp = output[j];
					output[j] = output[j + 1];
					output[j + 1] = temp;
				}
			}
		}
		return output;
	}
}
