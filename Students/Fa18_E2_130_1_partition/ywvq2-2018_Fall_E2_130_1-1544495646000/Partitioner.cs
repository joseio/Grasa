

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int start = values[0];
		int end = values[values.Length - 1];
		int partition = start;
		int i = 0;
		for (int j = 1; j <= values.Length - 1; j++)
		{
			if (values[j] < partition)
			{
				i++;
				//swap i and j
				int temp = values[i];
				values[i] = values[j];
				values[j] = temp;
			}
		}
		//swap i with partition at index, start 
		int temp_1 = values[i];
		values[i] = values[0];
		values[0] = temp_1;
		return i;
	}
}