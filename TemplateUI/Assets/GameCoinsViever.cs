using TMPro;
using UnityEngine;

public class GameCoinsViever : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI coinsCount_txt;

	private void Start()
	{
		PlayerController.instance.OnCoinsCountCahnged += CoinsCountChanged;
		coinsCount_txt.text = PlayerController.instance.CoinsCount.ToString();
	}

	private void CoinsCountChanged(int currentCoinsCount) =>
		coinsCount_txt.text = currentCoinsCount.ToString();
}