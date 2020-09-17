

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
			if (pivot > values[i])
			{
				pivotPosition++;
				temp = values[i];
				values[i] = values[pivotPosition];
				values[pivotPosition] = temp;
			}
		}
		temp = values[0];
		values[0] = values[pivotPosition];
		values[pivotPosition] = temp;
		return pivotPosition;
	}
}