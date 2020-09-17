

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
		int temp;
		for (int i = 1; i < values.Length; ++i)
		{
			if (values[i] < partition)
			{
				index++;
				temp = values[i];
				values[i] = values[index];
				values[index] = temp;
			}
		}
		temp = values[index];
		values[index] = values[0];
		values[0] = temp;
		return index;
	}
}