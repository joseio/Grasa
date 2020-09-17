

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length < 2)
		{
			return 0;
		}
		int p = values[0];
		/*        int p = values[0];
		int pv = 0;
		for (int i = 1; i < values.length; i++) {
		if (values[i] < p) {
		pv++;
		int tmp = values[pv];
		values[pv] = values[i];
		values[i] = tmp;
		}
		}
		pv--;
		int tmp = values[0];
		values[0] = values[pv];
		values[pv] = tmp;
		return pv;*/
		for (int i = 0; i < values.Length - 1; i++)
		{
			for (int j = i + 1; j < values.Length; j++)
			{
				if (values[i] > values[j])
				{
					int tmp = values[i];
					values[i] = values[j];
					values[j] = tmp;
				}
			}
		}
		for (int i = 0; i < values.Length; i++)
		{
			if (p == values[i])
			{
				return i;
			}
		}
		return 0;
	}
}