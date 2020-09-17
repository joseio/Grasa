

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int j = 1;
		int i = 1;
		for (i = 1; i < values.Length; i++, j++)
		{
			if (values[i] >= values[0])
			{
				while (j < values.Length && values[j] >= values[0])
				{
					j++;
				}
				if (j >= values.Length)
				{
					break;
				}
				int t = values[j];
				values[j] = values[i];
				values[i] = t;
			}
		}
		int t_1 = values[0];
		values[0] = values[i - 1];
		values[i - 1] = t_1;
		return i - 1;
	}
}