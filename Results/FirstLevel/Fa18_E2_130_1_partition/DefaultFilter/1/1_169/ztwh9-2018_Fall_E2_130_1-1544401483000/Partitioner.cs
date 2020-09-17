

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int small = 0;
		int large = 0;
		int piv = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < piv)
			{
				small++;
			}
			else
			{
				large++;
			}
		}
		int[] left = new int[small];
		int[] right = new int[large];
		int k = 0;
		int l = 0;
		for (int j = 1; j < values.Length; j++)
		{
			if (values[j] < piv)
			{
				left[k] = values[j];
				k++;
			}
			else
			{
				right[l] = values[j];
				l++;
			}
		}
		values[small] = values[0];
		int w = 0;
		for (int r = 0; r < left.Length; r++)
		{
			values[w] = left[r];
			w++;
		}
		w++;
		for (int d = 0; d < right.Length; d++)
		{
			values[w] = right[d];
			w++;
		}
		return small;
	}
}