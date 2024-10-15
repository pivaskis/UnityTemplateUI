using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private const string Playercontroller = "PlayerController";
	
	public static PlayerController playerController;

	public int GameCoins;
	public Ship Ship;

	private void Awake()
	{
		playerController = this;
		GameCoins = PlayerPrefs.GetInt(Playercontroller + "GameCoins", 0);
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt(Playercontroller + "GameCoins", GameCoins);
	}
}

[Serializable]
public class Ship
{
	public string ShipName;
	public Image Skin;
	public Image Icon;

	public int ballsCount;
}