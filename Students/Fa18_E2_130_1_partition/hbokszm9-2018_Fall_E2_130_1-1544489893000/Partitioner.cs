

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotIndex = 0;
		int pivotValue = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (pivotValue > values[i])
			{
				pivotIndex++;
				int tmp = values[pivotIndex];
				values[pivotIndex] = values[i];
				values[i] = tmp;
			}
		}
		int tmp_1 = values[pivotIndex];
		values[pivotIndex] = values[0];
		values[0] = tmp_1;
		return pivotIndex;
	}
}