using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public BallSpawner ballSpawner;
	public TextMeshPro counterText;

	public BoxContainerController boxController;

	public int countOfBalls;

	private int _counter = 0;


	private void Start()
	{
		StartCoroutine(BallSpawnerCoroutine());
		boxController.MultiplayerCounter += MultiplayCounter;
	}

	private void MultiplayCounter(int multiplayer)
	{
		_counter += multiplayer;

		counterText.text = _counter.ToString();
	}

	private IEnumerator BallSpawnerCoroutine()
	{
		yield return new WaitForSeconds(1);

		while (countOfBalls != 0)
		{
			ballSpawner.CreateBall();
			yield return new WaitForSeconds(5);
			countOfBalls--;
		}
	}
}