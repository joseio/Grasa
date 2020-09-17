

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int a = values[0];
		int[] result = new int[values.Length];
		int i = values.Length - 1;
		int j = 0;
		for (int t = 1; t < values.Length; t++)
		{
			if (values[t] >= a)
			{
				result[i] = values[t];
				i--;
			}
			else
			{
				result[j] = values[t];
				j++;
			}
		}
		result[j] = a;
		for (int k = 0; k < values.Length; k++)
		{
			values[k] = result[k];
		}
		return j;
	}
}