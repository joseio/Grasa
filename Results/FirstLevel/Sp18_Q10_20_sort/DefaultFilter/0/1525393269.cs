using System;

public class Program
{
	public static int[] sort(int[] array)
	{
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i - 1] > array[i])
			{
				int temp = array[i - 1];
				array[i - 1] = array[i];
				array[i] = temp;
			}
		}
		for (int i_1 = 1; i_1 < array.Length; i_1++)
		{
			if (array[i_1 - 1] > array[i_1])
			{
				sort(array);
			}
		}
		return array;
	}
}
