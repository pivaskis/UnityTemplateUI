using System.Collections.Generic;
using UnityEngine;

public class PlayGround : MonoBehaviour
{
	public List<Row> rows;
	public int levelNumber;
	public GameObject RowsContainer;

	public int distanceX;
	public int distanceY;
	public int scaleMultiplier;


	[ContextMenu("ReadRows")]
	public void ReadRows()
	{
		rows = new List<Row>();

		foreach (Transform row in RowsContainer.transform)
		{
			List<Circle> circles = new List<Circle>();

			foreach (Transform circle in row)
				circles.Add(new Circle(1, circle.position, null));

			rows.Add(new Row(circles));
		}
	}
}