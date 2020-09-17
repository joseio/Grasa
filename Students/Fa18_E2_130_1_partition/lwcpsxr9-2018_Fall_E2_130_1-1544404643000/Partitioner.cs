

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int temp1 = values[values.Length - 1];
		values[values.Length - 1] = values[0];
		values[0] = temp1;
		int pivot = values[values.Length - 1];
		int index = 0;
		int temp;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				temp = values[i];
				values[i] = values[index];
				values[index] = temp;
				index++;
			}
		}
		temp = values[index];
		values[index] = pivot;
		values[values.Length - 1] = temp;
		return index;
	}
}