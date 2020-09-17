

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		return partition(values, 0, values.Length);
	}

	private static int partition(int[] values, int start, int end)
	{
		int temp;
		int pivot = values[start];
		int pivotPosition = start;
		for (int i = start + 1; i < end; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				temp = values[i];
				values[i] = values[pivotPosition];
				values[pivotPosition] = temp;
			}
		}
		values[0] = values[pivotPosition];
		values[pivotPosition] = pivot;
		return pivotPosition;
	}
}