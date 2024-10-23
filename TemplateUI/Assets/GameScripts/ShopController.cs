using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
	public ShipsConfig shipsConfig;
	public GameObject grid;
	public GameObject ShipIconTemplate;
	public GameObject BuyMenu;
	public GameObject YouGotNoMoneyMenu;
	public BuyMenuController BuyMenuController;

	private Dictionary<int, ShopShipIcon> ShipIconsByName;

	private List<int> boughtShips = new List<int>();


	private void Awake()
	{
		ReadeBoughtShipsFromPlayerPrefs();

		ShipIconsByName = new Dictionary<int, ShopShipIcon>();
		foreach (Ball shipItem in shipsConfig.Ships)
		{
			GameObject instantiatedShip = Instantiate(ShipIconTemplate, grid.transform);
			ShopShipIcon shipIcon = instantiatedShip.GetComponent<ShopShipIcon>();

			shipIcon.OnShipIconSelected += OnShipIconSelected;

			shipIcon.ShipName = shipItem.BallName;
			shipIcon.icon.sprite = shipItem.Icon;
			shipIcon.price = shipItem.Price;

			if (shipItem.BallName == PlayerController.instance.ball.BallName)
			{
				shipIcon.priceTxt.text = "Current";
			}
			else if (boughtShips.Contains(shipItem.BallName))
			{
				shipIcon.priceTxt.text = "bought";
			}
			else
			{
				shipIcon.priceTxt.text = shipItem.Price.ToString();
			}

			instantiatedShip.SetActive(true);
			ShipIconsByName.Add(shipIcon.ShipName, shipIcon);
		}
	}

	private void OnDestroy()
	{
		WriteBoughtShipsToPlayerPrefs();
	}

	private void OnShipIconSelected(int shipName)
	{
		if (shipName == PlayerController.instance.ball.BallName)
			return;

		if (boughtShips.Contains(shipName))
		{
			PlayerController.instance.SetBall(shipsConfig.Ships[shipName]);
			ShipIconsByName[PlayerController.instance.ball.BallName].priceTxt.text = "bought";
			ShipIconsByName[shipName].priceTxt.text = "Current";
		}
		else
		{
			if (shipsConfig.Ships[shipName].Price > PlayerController.instance.GameCoins)
			{
				OpenYouGotNoMoney();
			}
			else
			{
				OpenBuyMenu(shipsConfig.Ships[shipName]);
			}
		}
	}

	private void OpenYouGotNoMoney()
	{
		StartCoroutine(OpenYouGotNoMoneyCoroutine());
	}

	private IEnumerator OpenYouGotNoMoneyCoroutine()
	{
		YouGotNoMoneyMenu.SetActive(true);
		yield return new WaitForSeconds(1);
		YouGotNoMoneyMenu.SetActive(false);
	}

	private void OpenBuyMenu(Ball ball)
	{
		BuyMenuController.SetShipData(ball);
		BuyMenuController.OnBought += OnShipBought;
		BuyMenu.SetActive(true);
	}

	private void OnShipBought(int shipName)
	{
		boughtShips.Add(shipName);
		ShipIconsByName[PlayerController.instance.ball.BallName].priceTxt.text = "bought";
		ShipIconsByName[shipName].priceTxt.text = "Current";
		PlayerController.instance.SetBall(shipsConfig.Ships[shipName]);
		PlayerController.instance.GameCoins -= shipsConfig.Ships[shipName].Price;
		CloseBuyMenu();
	}

	public void CloseBuyMenu()
	{
		BuyMenu.SetActive(false);
	}

	private void ReadeBoughtShipsFromPlayerPrefs()
	{
		string boughtShipsString = PlayerPrefs.GetString("ShopController_" + "BoughtShips", "0");
		var boughtShipsStringArray = boughtShipsString.Split(',');
		foreach (string item in boughtShipsStringArray)
		{
			var shipName = int.Parse(item);

			if (boughtShips.Contains(shipName))
				continue;

			boughtShips.Add(shipName);
		}
	}

	private void WriteBoughtShipsToPlayerPrefs()
	{
		string boughtShipsString = string.Join(",", boughtShips);
		PlayerPrefs.SetString("ShopController_" + "BoughtShips", boughtShipsString);
		PlayerPrefs.Save();
	}
}