using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private const string Playercontroller = "PlayerController_";

	public static PlayerController playerController;

	public int GameCoins;
	public Ship Ship;

	public ShipsConfig shipsConfig;

	private void Awake()
	{
		playerController = this;
		GameCoins = PlayerPrefs.GetInt(Playercontroller + "GameCoins", 0);
		var shipName = PlayerPrefs.GetInt(Playercontroller + "ShipName", 0);

		var ship = shipsConfig.GetShipByName(shipName);
		SetShip(ship);
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt(Playercontroller + "GameCoins", GameCoins);
		PlayerPrefs.SetInt(Playercontroller + "ShipName", Ship.ShipName);
	}

	public void SetShip(Ship ship)
	{
		Ship.ShipName = ship.ShipName;
		Ship.Icon = ship.Icon;
		Ship.Skin = ship.Skin;
		Ship.Price = ship.Price;
	}
}