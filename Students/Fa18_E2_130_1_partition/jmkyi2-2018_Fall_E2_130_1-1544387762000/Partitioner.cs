

public class Partitioner
{
	public static int partition(int[] values)
	{
		// error cases
		if (values == null)
		{
			return 0;
		}
		if (values.Length == 0)
		{
			return 0;
		}
		if (values.Length == 1)
		{
			return 0;
		}
		// get position p
		int size = values.Length;
		int p = 0;
		int pivot = values[0];
		for (int i = 1; i < size; i++)
		{
			if (values[i] < pivot)
			{
				p++;
			}
		}
		// creates arrays for lower and high numbers
		int[] small = new int[p + 1];
		int scount = 0;
		int[] large = new int[size - p];
		int lcount = 0;
		//
		for (int i = 0; i < size; i++)
		{
			if (values[i] < pivot)
			{
				small[scount] = values[i];
				scount++;
			}
			else
			{
				large[lcount] = values[i];
				lcount++;
			}
		}
		for (int i = 0; i < p; i++)
		{
			values[i] = small[i];
		}
		values[p] = pivot;
		for (int i = p + 1; i < size; i++)
		{
			values[i] = large[i - p];
		}
		return p;
	}
}