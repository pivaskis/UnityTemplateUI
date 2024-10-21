using System;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	public TextMeshProUGUI GameCoins;

	private void OnEnable()
	{
		if (PlayerController.instance == null)
			return;

		GameCoins.text = PlayerController.instance.GameCoins.ToString();
	}

	private void Start()
	{
		GameCoins.text = PlayerController.instance.GameCoins.ToString();
	}
}