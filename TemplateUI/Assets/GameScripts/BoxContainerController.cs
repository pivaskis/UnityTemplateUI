using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxContainerController : MonoBehaviour
{
	public event Action<int> MultiplayerCounter;

	private List<Box> Boxes;

	private void OnEnable()
	{
		Boxes = new List<Box>();

		foreach (Transform boxTransform in transform)
		{
			var boxItem = boxTransform.GetChild(0).GetComponent<Box>();
			Boxes.Add(boxItem);
			boxItem.OnBallCollision += OnBallCollision;
		}
	}

	private void OnBallCollision(int multiplayer) => MultiplayerCounter?.Invoke(multiplayer);
}