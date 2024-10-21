using System;
using UnityEngine;

[Serializable]
public class Circle
{
	public int enabled;
	public Vector3 localPosition;
	public Sprite sprite;

	public Circle(int enabled, Vector3 localPosition, Sprite sprite)
	{
		this.enabled = enabled;
		this.localPosition = localPosition;
		this.sprite = sprite;
	}
}