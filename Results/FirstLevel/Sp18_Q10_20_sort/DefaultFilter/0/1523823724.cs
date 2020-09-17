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
		if (array == null || array.Length == 0)
		{
			return array;
		}
		quick(array, 0, array.Length - 1);
		return array;
	}

	public static void quick(int[] array, int left, int right)
	{
		if (left >= right)
		{
			return;
		}
		int pivot = left + (right - left) / 2;
		swap(array, pivot, right);
		int l = left;
		int r = right - 1;
		while (l <= r)
		{
			if (array[l] < array[right])
			{
				l++;
			}
			else
			{
				if (array[r] > array[right])
				{
					r--;
				}
				else
				{
					swap(array, l, r);
					l++;
					r--;
				}
			}
		}
		swap(array, l, right);
		quick(array, left, r);
		quick(array, l + 1, right);
	}

	public static void swap(int[] array, int i, int j)
	{
		int temp = array[i];
		array[i] = array[j];
		array[j] = temp;
	}
}
