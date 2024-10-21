using System;
using System.Collections.Generic;

[Serializable]
public class Row
{
	public List<Circle> circles;

	public Row(List<Circle> circles)
	{
		this.circles = circles;
	}
}