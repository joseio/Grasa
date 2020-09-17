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
		int[] output = new int[array.Length];
		for (int j = 0; j < output.Length; j++)
		{
			output[j] = array[j];
		}
		System.Console.Out.println();
		for (int i = 1; i < output.Length; i++)
		{
			int toInsert = output[i];
			for (int j_1 = i; j_1 > 0; j_1--)
			{
				if (output[j_1 - 1] > output[j_1])
				{
					output[j_1] = output[j_1 - 1];
					output[j_1 - 1] = toInsert;
				}
				else
				{
					break;
				}
			}
		}
		return output;
	}
}
