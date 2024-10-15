using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
	public int levelNumber;
	public TextMeshProUGUI LevelTxt;
	public GameObject Locker;
	public event Action<int> OnLevelSelected;

	private void OnEnable()
	{
		if (levelNumber == 1 || (PlayerPrefs.HasKey("level " + levelNumber) && PlayerPrefs.GetInt("level " + levelNumber) == 1))
		{
			LevelTxt.gameObject.SetActive(true);
			LevelTxt.text = levelNumber.ToString();
			Locker.SetActive(false);
		}
		else
		{
			transform.GetComponent<Button>().interactable = false;
		}
	}

	public void SelectLevel()
	{
		OnLevelSelected?.Invoke(levelNumber);
	}
}