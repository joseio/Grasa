

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
		int tmp = 0;
		int pivot = values[0];
		int pposition = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pposition++;
				tmp = values[pposition];
				values[pposition] = values[i];
				values[i] = tmp;
			}
		}
		tmp = values[pposition];
		values[pposition] = pivot;
		values[0] = tmp;
		return pposition;
	}
}