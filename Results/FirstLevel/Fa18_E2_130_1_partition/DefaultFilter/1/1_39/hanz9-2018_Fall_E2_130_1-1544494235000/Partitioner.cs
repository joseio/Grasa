

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotPosition = 0;
		int pivot = values[0];
		int temp;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				temp = values[pivotPosition];
				values[pivotPosition] = values[i];
				values[i] = temp;
				pivotPosition++;
			}
		}
		temp = values[pivotPosition];
		values[pivotPosition] = pivot;
		values[values.Length - 1] = temp;
		return pivotPosition;
	}
}