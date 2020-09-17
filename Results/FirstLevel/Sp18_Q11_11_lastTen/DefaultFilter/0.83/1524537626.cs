using System;

public class LastTen
{
	internal int[] lastTen;

	public virtual void add(int newValue)
	{
		for (int i = 0; i < 9; i++)
		{
			lastTen[i] = lastTen[i + 1];
		}
		lastTen[10] = newValue;
	}

	public virtual int[] getLastTen()
	{
		return lastTen;
	}
}
