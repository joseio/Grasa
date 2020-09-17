

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivIndex = 0;
		int piv = values[0];
		int i = values.Length - 1;
		for (int j = values.Length - 1; j >= 1; j--)
		{
			if (values[j] >= piv)
			{
				int temp = values[j];
				values[j] = values[i];
				values[i] = temp;
				i--;
			}
		}
		int temp_1 = values[pivIndex];
		values[pivIndex] = values[i];
		values[i] = temp_1;
		return i;
	}
}