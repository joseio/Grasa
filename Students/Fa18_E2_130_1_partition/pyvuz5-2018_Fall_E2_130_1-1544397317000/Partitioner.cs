

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
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				int temp = values[i];
				values[i] = values[pivotPosition];
				values[pivotPosition] = temp;
			}
		}
		int temp_1 = values[pivotPosition];
		values[pivotPosition] = pivot;
		values[0] = temp_1;
		return pivotPosition;
	}
}