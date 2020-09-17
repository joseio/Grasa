

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
		int[] geoff = new int[values.Length];
		int count = 0;
		int critical = 0;
		int test = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < test)
			{
				geoff[count] = values[i];
				count++;
			}
		}
		critical = count;
		geoff[count] = test;
		count++;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] >= test)
			{
				geoff[count] = values[i];
				count++;
			}
		}
		for (int i = 0; i < values.Length; i++)
		{
			values[i] = geoff[i];
		}
		return critical;
	}
}