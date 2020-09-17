

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pos = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < values[0] && i > (pos + 1))
			{
				pos += 1;
				int temp = values[i];
				values[i] = values[pos];
				values[pos] = temp;
			}
			else if (values[i] < values[0])
			{
				pos += 1;
			}
		}
		int temp_1 = values[pos];
		values[pos] = values[0];
		values[0] = temp_1;
		return pos;
	}
}