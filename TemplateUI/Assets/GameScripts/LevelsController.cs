using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
	public GameObject[] GreedLevels;
	public event Action<int> OnLevelSelected;

	public GameObject NextButtonImg;
	public GameObject BackButtonImg;
	public GameObject LevelIcon;

	[SerializeField] private LevelsConfig _levelsConfig;
	private List<Level> _levels = new();
	private List<Button> levelsButtons = new();

	private void Awake()
	{
		int levelsCount = _levelsConfig.Levels.Count;

		int greedCounter = 0;

		for (int i = 0; i < levelsCount; i++)
		{
			if (i % 12 == 0 && i != 0)
				greedCounter++;

			var level = Instantiate(LevelIcon, GreedLevels[greedCounter].transform).GetComponent<Level>();
			level.levelNumber = i + 1;
			level.OnLevelSelected += LevelSelected;

			_levels.Add(level);
			levelsButtons.Add(level.GetComponent<Button>());
		}
	}

	private void OnEnable()
	{
		foreach (Level level in _levels) level.ConfigureIconLevel();
	}

	private void SetInteractable(bool isInteractable)
	{
		foreach (Button levelButton in levelsButtons) levelButton.interactable = isInteractable;
	}

	public void NextLevelsPage()
	{
		foreach (GameObject greed in GreedLevels)
			greed.gameObject.SetActive(!greed.gameObject.activeSelf);

		NextButtonImg.SetActive(!NextButtonImg.activeSelf);
		BackButtonImg.SetActive(!BackButtonImg.activeSelf);
	}

	private void LevelSelected(int levelNumber)
	{
		SetInteractable(false);
		OnLevelSelected?.Invoke(levelNumber);
	}
}