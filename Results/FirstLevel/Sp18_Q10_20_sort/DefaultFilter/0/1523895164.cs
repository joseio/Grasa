using System;

public class Program
{
	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// Note that you may not use java.util.Arrays.
	/// </remarks>
	public static int[] sort(int[] inputArray)
	{
		for (int i = 1; i < inputArray.Length; i++)
		{
			int toInsert = inputArray[i];
			for (int j = i; j > 0; j--)
			{
				if (inputArray[j - 1] > toInsert)
				{
					inputArray[j] = inputArray[j - 1];
					inputArray[j - 1] = toInsert;
				}
			}
		}
		return inputArray;
	}
}
