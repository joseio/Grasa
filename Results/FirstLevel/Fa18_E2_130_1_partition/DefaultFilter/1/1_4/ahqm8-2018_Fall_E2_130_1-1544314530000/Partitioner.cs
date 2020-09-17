

public class Partitioner
{
	public static int partition(int[] vals)
	{
		if (vals == null || vals.Length == 0)
		{
			return 0;
		}
		int p = 1;
		for (int i = 1; i < vals.Length; i++)
		{
			if (vals[i] < vals[0])
			{
				int temp = vals[i];
				vals[i] = vals[p];
				vals[p] = temp;
				p++;
			}
		}
		p--;
		int temp_1 = vals[0];
		vals[0] = vals[p];
		vals[p] = temp_1;
		return p;
	}
}