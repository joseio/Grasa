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
		/*for (int i = 0; i < array.length; i++) {
		System.out.print(array[i] + ", ");
		}
		System.out.println(); */
		int[] arr = new int[array.Length];
		int counter = -1;
		for (int i = 0; i < array.Length; i++)
		{
			//System.out.println("putting " + array[i]);
			bool h = true;
			for (int k = 0; k < arr.Length && h; k++)
			{
				//System.out.println("looking at " + arr[k] + " at k=" + k);
				if (k > counter)
				{
					//System.out.println("k<counter, counter= " + counter + ", k =" + k);
					arr[k] = array[i];
					counter++;
					h = false;
				}
				else
				{
					if (array[i] < arr[k])
					{
						///System.out.println("array<arr");
						//arr = shift(arr, k);
						for (int j = arr.Length - 1; j > k; j--)
						{
							arr[j] = arr[j - 1];
						}
						arr[k] = array[i];
						counter++;
						h = false;
					}
				}
			}
		}
		/*for (int i = 0; i < arr.length; i++) {
		System.out.print(arr[i] + ", ");
		}
		System.out.println();*/
		return arr;
	}
}
