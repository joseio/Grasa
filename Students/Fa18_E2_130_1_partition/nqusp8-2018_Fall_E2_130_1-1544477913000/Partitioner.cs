

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int start = 0;
		int pivot = values[start];
		int pivotPosition = start;
		int tmp;
		for (int i = start + 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				tmp = values[i];
				values[i] = values[pivotPosition];
				values[pivotPosition] = tmp;
			}
		}
		tmp = pivot;
		values[start] = values[pivotPosition];
		values[pivotPosition] = tmp;
		return pivotPosition;
	}
}