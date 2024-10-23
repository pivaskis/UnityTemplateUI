using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private const string Playercontroller = "PlayerController_";

	public static PlayerController instance;

	public int GameCoins;
	public Ball ball;

	public ShipsConfig shipsConfig;

	public int ballsCount = 6;

	private void Awake()
	{
		instance = this;
		GameCoins = PlayerPrefs.GetInt(Playercontroller + "GameCoins", 0);
		var shipName = PlayerPrefs.GetInt(Playercontroller + "ShipName", 0);

		var ship = shipsConfig.GetShipByName(shipName);
		SetBall(ship);
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt(Playercontroller + "GameCoins", GameCoins);
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