using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
	public GameObject[] GreedLevels;
	public event Action<int> OnLevelSelected;

	public GameObject NextButtonImg;
	public GameObject BackButtonImg;


	private void Start()
	{
		foreach (GameObject greed in GreedLevels)
		{
			foreach (Transform levelTransform in greed.transform)
			{
				var level = levelTransform.GetComponent<Level>();
				level.OnLevelSelected += LevelSelected;
			}
		}
	}

	public void SetInteractable(bool isInteractable)
	{
		foreach (GameObject greed in GreedLevels)
		{
			foreach (Transform levelTransform in greed.transform)
			{
				var levelButton = levelTransform.GetComponent<Button>();
				levelButton.interactable = isInteractable;
			}
		}
	}

	public void NextLevelsPage()
	{
		foreach (GameObject greed in GreedLevels) 
			greed.gameObject.SetActive(!greed.gameObject.activeSelf);
		
		NextButtonImg.SetActive(!NextButtonImg.activeSelf);
		BackButtonImg.SetActive(!BackButtonImg.activeSelf);
	}

	private void LevelSelected(int levelNumber) =>
		OnLevelSelected?.Invoke(levelNumber);
}