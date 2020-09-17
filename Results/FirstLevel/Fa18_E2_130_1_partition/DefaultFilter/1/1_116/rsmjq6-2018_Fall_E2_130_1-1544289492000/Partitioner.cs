

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotPosition = 0;
		int pivotValue = values[pivotPosition];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivotValue)
			{
				pivotPosition++;
				int temp = values[pivotPosition];
				values[pivotPosition] = values[i];
				values[i] = temp;
			}
		}
		int temp_1 = values[pivotPosition];
		values[pivotPosition] = values[0];
		values[0] = temp_1;
		return pivotPosition;
	}
}