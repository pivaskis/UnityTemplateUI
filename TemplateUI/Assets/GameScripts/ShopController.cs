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
		foreach (Ship shipItem in shipsConfig.Ships)
		{
			GameObject instantiatedShip = GameObject.Instantiate(ShipIconTemplate, grid.transform);
			ShopShipIcon shipIcon = instantiatedShip.GetComponent<ShopShipIcon>();

			shipIcon.OnShipIconSelected += OnShipIconSelected;

			shipIcon.ShipName = shipItem.ShipName;
			shipIcon.icon.sprite = shipItem.Icon;
			shipIcon.price = shipItem.Price;

			if (shipItem.ShipName == PlayerController.playerController.Ship.ShipName)
			{
				shipIcon.priceTxt.text = "Current";
			}
			else if (boughtShips.Contains(shipItem.ShipName))
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
		if (shipName == PlayerController.playerController.Ship.ShipName)
			return;

		if (boughtShips.Contains(shipName))
		{
			PlayerController.playerController.SetShip(shipsConfig.Ships[shipName]);
			ShipIconsByName[PlayerController.playerController.Ship.ShipName].priceTxt.text = "bought";
			ShipIconsByName[shipName].priceTxt.text = "Current";
		}
		else
		{
			if (shipsConfig.Ships[shipName].Price > PlayerController.playerController.GameCoins)
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

	private void OpenBuyMenu(Ship ship)
	{
		BuyMenuController.SetShipData(ship);
		BuyMenuController.OnBought += OnShipBought;
		BuyMenu.SetActive(true);
	}

	private void OnShipBought(int shipName)
	{
		boughtShips.Add(shipName);
		ShipIconsByName[PlayerController.playerController.Ship.ShipName].priceTxt.text = "bought";
		ShipIconsByName[shipName].priceTxt.text = "Current";
		PlayerController.playerController.SetShip(shipsConfig.Ships[shipName]);
		PlayerController.playerController.GameCoins -= shipsConfig.Ships[shipName].Price;
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