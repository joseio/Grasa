

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null)
		{
			return 0;
		}
		if (values.Length == 0 || values.Length == 1)
		{
			return 0;
		}
		int position = 0;
		int partition = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < partition)
			{
				position++;
				int tmp = values[i];
				values[i] = values[position];
				values[position] = tmp;
			}
		}
		int tmp_1 = values[position];
		values[position] = values[0];
		values[0] = tmp_1;
		return position;
	}
}