

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
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				temp = values[i];
				values[i] = values[pivotPosition];
				values[pivotPosition] = temp;
			}
		}
		temp = values[pivotPosition];
		values[pivotPosition] = values[0];
		values[0] = temp;
		return pivotPosition;
	}
}