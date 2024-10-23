using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private const string Playercontroller = "PlayerController_";

	public static PlayerController instance;

	public Ball ball;

	public ShipsConfig shipsConfig;

	public int ballsCount = 6;
	public event Action<int> OnCoinsCountCahnged;

	public int CoinsCount { get; private set; }

	private void Awake()
	{
		instance = this;
		CoinsCount = PlayerPrefs.GetInt(Playercontroller + "GameCoins", 0);
		int shipName = PlayerPrefs.GetInt(Playercontroller + "ShipName", 0);

		Ball ship = shipsConfig.GetShipByName(shipName);
		SetBall(ship);
	}

	public void ChangeCoinsCount(int coinsCount)
	{
		CoinsCount += coinsCount;
		OnCoinsCountCahnged?.Invoke(CoinsCount);
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt(Playercontroller + "GameCoins", CoinsCount);
		PlayerPrefs.SetInt(Playercontroller + "ShipName", ball.BallName);
	}

	public void SetBall(Ball ball)
	{
		this.ball.BallName = ball.BallName;
		this.ball.Icon = ball.Icon;
		this.ball.Skin = ball.Skin;
		this.ball.Price = ball.Price;
		this.ball.physicsMaterial = ball.physicsMaterial;
	}
}