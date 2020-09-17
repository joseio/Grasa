

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int squeeg = 0;
		int pivoot = values[0];
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivoot)
			{
				values[squeeg] = values[i];
				int temp = values[squeeg + 1];
				values[squeeg + 1] = pivoot;
				values[i] = temp;
				squeeg++;
			}
		}
		values[squeeg] = pivoot;
		Console.WriteLine(squeeg + "  pivot " + pivoot);
		for (int i = 0; i < values.Length; i++)
		{
			Console.WriteLine(i + " " + values[i]);
		}
		return squeeg;
	}
}