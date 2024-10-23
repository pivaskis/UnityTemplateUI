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

	private void Start() => LevelTxt.text = levelNumber.ToString();

	public void ConfigureIconLevel()
	{
		LevelTxt.text = levelNumber.ToString();
		if (levelNumber == 1 || (PlayerPrefs.HasKey("level " + levelNumber) && PlayerPrefs.GetInt("level " + levelNumber) == 1))
		{
			Locker.SetActive(false);
			transform.GetComponent<Button>().interactable = true;
		}
		else
		{
			transform.GetComponent<Button>().interactable = false;
		}
	}

	public void SelectLevel() => OnLevelSelected?.Invoke(levelNumber);
}