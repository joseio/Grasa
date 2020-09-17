

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
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int temp = values[i];
				values[i] = values[pivotPosition];
				values[pivotPosition] = temp;
				pivotPosition++;
			}
		}
		int temp_1 = values[pivotPosition];
		values[pivotPosition] = pivot;
		return pivotPosition;
	}
}