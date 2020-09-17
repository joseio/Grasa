using System;

public class Program
{
	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// Note that you may not use java.util.Arrays.
	/// </remarks>
	public static int[] merge(int[] first, int[] second)
	{
		int[] newArray = new int[first.Length + second.Length];
		int firstIndex = 0;
		int secondIndex = 0;
		for (int i = 0; i < newArray.Length; i++)
		{
			if (firstIndex < first.Length && secondIndex < second.Length)
			{
				if (first[firstIndex] < second[secondIndex])
				{
					newArray[i] = first[firstIndex];
					firstIndex++;
				}
				else
				{
					newArray[i] = second[secondIndex];
					secondIndex++;
				}
			}
			else
			{
				if (firstIndex > first.Length)
				{
					newArray[i] = second[secondIndex];
					secondIndex++;
				}
				else
				{
					if (secondIndex > second.Length)
					{
						newArray[i] = first[firstIndex];
						firstIndex++;
					}
				}
			}
		}
		return newArray;
	}

	public static int[] sort(int[] array)
	{
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
