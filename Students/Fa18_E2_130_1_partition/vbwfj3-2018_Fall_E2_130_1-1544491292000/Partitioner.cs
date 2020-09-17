

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int start = values[0];
		int num = 0;
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < start)
			{
				num++;
				temp = values[num];
				values[num] = values[i];
				values[i] = temp;
			}
		}
		temp = values[num];
		values[num] = values[0];
		values[0] = temp;
		return num;
	}
}