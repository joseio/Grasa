using System;

public class Program
{
	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// Note that you may not use java.util.Arrays.
	/// </remarks>
	public static int[] sort(int[] arr)
	{
		//Bubble sort is easy to code, even if it is terrible
		bool done = false;
		while (!done)
		{
			done = true;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				if (arr[i] > arr[i + 1])
				{
					done = false;
					int temp = arr[i];
					arr[i] = arr[i + 1];
					arr[i + 1] = temp;
				}
			}
		}
		return arr;
	}
}
