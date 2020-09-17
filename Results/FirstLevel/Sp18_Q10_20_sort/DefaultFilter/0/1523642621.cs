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
		for (int i = 0; i < inputArray.Length; i++)
		{
			int toInsert = inputArray[i];
			for (int j = i; j > 0; j--)
			{
				if (toInsert < inputArray[j - 1])
				{
					inputArray[j] = inputArray[j - 1];
					inputArray[j - 1] = toInsert;
				}
				else
				{
					break;
				}
			}
		}
		return inputArray;
	}
}
