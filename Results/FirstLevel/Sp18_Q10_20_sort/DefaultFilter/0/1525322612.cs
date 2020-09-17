using System;

public class Program
{
	public static int[] sort(int[] array)
	{
		int n = array.Length;
		int[] arr = new int[n];
		for (int i = 0; i < n; i++)
		{
			arr[i] = array[i];
		}
		for (int i_1 = 1; i_1 < n; i_1++)
		{
			int key = arr[i_1];
			int j = i_1 - 1;
			while (j >= 0 && arr[j] > key)
			{
				arr[j + 1] = arr[j];
				j = j - 1;
			}
			arr[j + 1] = key;
		}
		return arr;
	}
}
