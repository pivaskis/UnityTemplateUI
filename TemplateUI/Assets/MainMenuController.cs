using System;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	public TextMeshProUGUI GameCoins;

	private void OnEnable()
	{
		if (PlayerController.playerController == null)
			return;

		GameCoins.text = PlayerController.playerController.GameCoins.ToString();
	}

	private void Start()
	{
		GameCoins.text = PlayerController.playerController.GameCoins.ToString();
	}
}