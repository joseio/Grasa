

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int temp;
		int pivotPosition = 0;
		for (int i = 1; i < values.Length; i++)
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
		values[0] = temp;
		return pivotPosition;
	}
}