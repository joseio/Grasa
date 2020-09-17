

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int temp;
		int start = 0;
		int pivot = values[start];
		int pivotPosition = start;
		for (int i = start; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				temp = values[pivotPosition];
				values[pivotPosition] = values[i];
				values[i] = temp;
			}
		}
		temp = values[pivotPosition];
		values[pivotPosition] = pivot;
		values[start] = temp;
		return pivotPosition;
	}
}