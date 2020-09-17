

public class Partitioner
{
	public static int partition(int[] array)
	{
		if (array == null)
		{
			return 0;
		}
		if (array.Length == 0)
		{
			return 0;
		}
		int pivot = array[0];
		int pivotposition = 0;
		int temp;
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] < pivot)
			{
				pivotposition++;
				temp = array[i];
				array[i] = array[pivotposition];
				array[pivotposition] = temp;
			}
		}
		temp = array[pivotposition];
		array[pivotposition] = array[0];
		array[0] = temp;
		return pivotposition;
	}
}