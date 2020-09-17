

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotValue = values[0];
		int pivotIndex = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivotValue)
			{
				pivotIndex++;
				int temp = values[i];
				values[i] = values[pivotIndex];
				values[pivotIndex] = temp;
			}
		}
		int temp_1 = values[0];
		values[0] = values[pivotIndex];
		values[pivotIndex] = temp_1;
		return pivotIndex;
	}
}