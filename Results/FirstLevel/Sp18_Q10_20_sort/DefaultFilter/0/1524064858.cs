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
		bool bubble = true;
		while (bubble)
		{
			bubble = false;
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] > array[i + 1])
				{
					bubble = true;
					int temp = array[i];
					array[i] = array[i + 1];
					array[i + 1] = temp;
				}
			}
		}
		return array;
	}
}
