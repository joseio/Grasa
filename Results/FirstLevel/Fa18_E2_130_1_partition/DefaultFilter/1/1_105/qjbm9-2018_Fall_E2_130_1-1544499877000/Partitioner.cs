

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length <= 1)
		{
			return 0;
		}
		int pivotPosition = 0;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < values[0])
			{
				int temp = values[i];
				values[i] = values[pivotPosition + 1];
				values[pivotPosition + 1] = temp;
				pivotPosition++;
			}
		}
		int temp_1 = values[0];
		values[0] = values[pivotPosition];
		values[pivotPosition] = temp_1;
		return pivotPosition;
	}
}