

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int partition = values[0];
		int index = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < partition)
			{
				index++;
				int temp = values[i];
				values[i] = values[index];
				values[index] = temp;
			}
		}
		int temp_1 = values[index];
		values[index] = partition;
		values[0] = temp_1;
		return index;
	}
}