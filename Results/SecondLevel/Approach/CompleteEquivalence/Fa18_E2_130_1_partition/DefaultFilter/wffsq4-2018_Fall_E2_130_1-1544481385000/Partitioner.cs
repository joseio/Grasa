

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		if (values.Length == 1)
		{
			return 0;
		}
		if (values.Length == 2 && values[0] < values[1])
		{
			return 0;
		}
		else if (values.Length == 2)
		{
			return 1;
		}
		int index = 1;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < values[0])
			{
				if (i != index)
				{
					int temp = values[i];
					values[i] = values[index];
					values[index] = temp;
				}
				index++;
			}
		}
		index--;
		Console.WriteLine(values[0]);
		int temp_1 = values[0];
		values[0] = values[index];
		values[index] = temp_1;
		for (int i = 0; i < values.Length; i++)
		{
			Console.WriteLine(values[i]);
			if (i == index - 1)
			{
				Console.Write("index   ");
			}
		}
		return index;
	}
}