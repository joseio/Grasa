

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotPosition = 0;
		int tmp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				tmp = values[pivotPosition];
				values[pivotPosition] = values[i];
				values[i] = tmp;
			}
		}
		tmp = values[pivotPosition];
		values[pivotPosition] = pivot;
		values[0] = tmp;
		return pivotPosition;
	}
}