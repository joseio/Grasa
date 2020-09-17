

public class Partitioner
{
	public static int partition(int[] values)
	{
		int pos = 0;
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int val = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < val)
			{
				int temp = values[i];
				for (int j = i; j > 0; j--)
				{
					values[j] = values[j - 1];
				}
				values[0] = temp;
				pos++;
			}
		}
		return pos;
	}
}