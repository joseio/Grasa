

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length < 2)
		{
			return 0;
		}
		int[] a = new int[values.Length];
		int i = 0;
		int j = a.Length - 1;
		for (int index = 1; index < values.Length; index++)
		{
			if (values[index] < values[0])
			{
				a[i] = values[index];
				i++;
			}
			else
			{
				a[j] = values[index];
				j--;
			}
			if (j - i <= 0)
			{
				break;
			}
		}
		a[i] = values[0];
		for (int k = 0; k < a.Length; k++)
		{
			values[k] = a[k];
		}
		return i;
	}
}