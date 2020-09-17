

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int partitionPosition = 0;
		int partition = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < partition)
			{
				int temp = values[i];
				values[i] = partition;
				partitionPosition++;
				values[partitionPosition] = temp;
			}
		}
		int temp_1 = values[partitionPosition];
		values[partitionPosition] = values[0];
		values[0] = temp_1;
		return partitionPosition;
	}
}