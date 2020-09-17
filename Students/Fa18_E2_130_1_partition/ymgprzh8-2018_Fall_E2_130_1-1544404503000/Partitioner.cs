

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotposition = 0;
		int temp;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				temp = values[pivotposition];
				values[pivotposition] = values[i];
				values[i] = temp;
				pivotposition++;
			}
		}
		temp = values[pivotposition];
		values[pivotposition] = pivot;
		pivot = temp;
		return pivotposition;
	}
}