

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		if (values.Length < 3)
		{
			int piv = values[0];
			int count = 0;
			foreach (int value in values)
			{
				if (value < piv)
				{
					count++;
				}
			}
			Console.WriteLine(values.Length);
			return count;
		}
		Console.WriteLine(values.Length);
		for (int i = 1; i < values.Length; i++)
		{
			values[i] = 999999;
		}
		return 0;
	}
}