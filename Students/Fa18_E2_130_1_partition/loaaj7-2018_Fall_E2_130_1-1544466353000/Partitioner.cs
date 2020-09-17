

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int lastPartitioned = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < values[0])
			{
				lastPartitioned++;
				int tmp = values[lastPartitioned];
				values[lastPartitioned] = values[i];
				values[i] = tmp;
			}
		}
		int tmp_1 = values[lastPartitioned];
		values[lastPartitioned] = values[0];
		values[0] = tmp_1;
		return lastPartitioned;
	}
}