using System;

public class LastTen
{
	public int[] value = new int[10];

	public int count = 0;

	public virtual void add(int newValue)
	{
		value[count] = newValue;
		count++;
		if (count >= 10)
		{
			count -= 10;
		}
	}

	public virtual int[] getLastTen()
	{
		return value;
	}

	public LastTen()
	{
	}
}
