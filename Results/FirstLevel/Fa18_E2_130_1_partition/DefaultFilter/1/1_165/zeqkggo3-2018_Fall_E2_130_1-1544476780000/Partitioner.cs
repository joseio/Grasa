

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotPosition = 0;
		int pivotValue = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivotValue)
			{
				pivotPosition++;
				int temp = values[i];
				values[i] = values[pivotPosition];
				values[pivotPosition] = temp;
			}
		}
		int temp2 = values[0];
		values[0] = values[pivotPosition];
		values[pivotPosition] = temp2;
		return pivotPosition;
	}
}