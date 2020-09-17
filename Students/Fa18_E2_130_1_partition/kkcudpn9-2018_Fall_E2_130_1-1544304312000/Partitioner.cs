

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length <= 1)
		{
			return 0;
		}
		int pivotValue = values[0];
		int pivotPosition = 1;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivotValue)
			{
				if (i > pivotPosition)
				{
					int temp = values[i];
					values[i] = values[pivotPosition];
					values[pivotPosition] = temp;
				}
				pivotPosition++;
			}
		}
		if (pivotValue < values[1])
		{
			return 0;
		}
		values[0] = values[pivotPosition - 1];
		values[pivotPosition - 1] = pivotValue;
		return pivotPosition - 1;
	}
}