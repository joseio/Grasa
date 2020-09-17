

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int part = values[0];
		int temp = 0;
		for (int i = 0; i < values.Length; i++)
		{
			for (int j = i; j < values.Length; j++)
			{
				if (values[i] > values[j])
				{
					temp = values[j];
					values[j] = values[i];
					values[i] = temp;
				}
			}
		}
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] == part)
			{
				return i;
			}
		}
		return 0;
	}
}