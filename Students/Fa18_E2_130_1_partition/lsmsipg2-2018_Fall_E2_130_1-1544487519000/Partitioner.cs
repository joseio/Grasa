

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int[] yee = new int[values.Length];
		int counter = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < values[0])
			{
				yee[counter] = values[i];
				counter++;
			}
		}
		yee[counter] = values[0];
		int returnMe = counter;
		counter++;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] > values[0])
			{
				yee[counter] = values[i];
				counter++;
			}
		}
		for (int i = 0; i < values.Length; i++)
		{
			values[i] = yee[i];
		}
		return returnMe;
	}
}