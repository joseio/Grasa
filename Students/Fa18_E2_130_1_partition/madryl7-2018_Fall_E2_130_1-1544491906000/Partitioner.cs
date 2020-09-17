

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotp = 0;
		int temp = 0;
		for (int i = 0; i < values.Length; i++)
		{
			if (pivot > values[i])
			{
				pivotp++;
				temp = values[pivotp];
				values[pivotp] = values[i];
				values[i] = temp;
			}
		}
		temp = values[pivotp];
		values[pivotp] = values[0];
		values[0] = temp;
		return pivotp;
	}
}