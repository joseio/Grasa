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
		int n = array.Length;
		int[] arr = new int[n];
		for (int i = 0; i < n; i++)
		{
			arr[i] = array[i];
		}
		for (int i_1 = 0; i_1 < n; i_1++)
		{
			for (int j = 0; j < n - 1 - i_1; j++)
			{
				//System.out.println("j: " + arr[j] + ", j + 1:" + arr[j + 1]);
				if (arr[j] > arr[j + 1])
				{
					int temp = arr[j];
					arr[j] = arr[j + 1];
					arr[j + 1] = temp;
				}
			}
		}
		return arr;
	}
}
