using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
	public GameObject GameScene;
	public GameObject GameMenu;
	public GameObject MainMenu;
	public GameObject Option;
	public GameObject LevelsMenu;
	public GameObject YouWinMenu;
	public GameObject TryAgain;
	public LevelsController levelsController;
	public GameController gameController;

	public Button PlayButton;
	public Button OptionButton;
	public Button MainMenuButton;
	public Button GameOptionButton;

	private void OnEnable()
	{
		levelsController.OnLevelSelected += OnLevelSelected;
		gameController.LevelComplete += OnLevelComplete;
	}

	public void OpenMainScene() =>
		StartCoroutine(OpenMainSceneCoroutine());

	private void OnLevelComplete(bool isCompleted)
	{
		if (isCompleted)
		{
			OpenYouWin();
		}
		else
		{
			OpenTryAgain();
		}
	}

	private void OpenTryAgain() => 
		TryAgain.SetActive(true);


	private void OnLevelSelected(int levelNumber)
	{
		StartCoroutine(OpenGameSceneCoroutine(levelNumber));
	}

	private IEnumerator OpenMainSceneCoroutine()
	{
		MainMenuButton.interactable = false;
		GameOptionButton.interactable = false;
		yield return new WaitForSeconds(1);
		GameScene.SetActive(false);
		GameMenu.SetActive(false);
		MainMenu.SetActive(true);
		PlayButton.interactable = true;
		OptionButton.interactable = true;
	}

	public void OpenLevelsMenu()
	{
		StartCoroutine(OpenLevelsMenuCoroutine());
	}

	private IEnumerator OpenLevelsMenuCoroutine()
	{
		PlayButton.interactable = false;
		OptionButton.interactable = false;
		yield return new WaitForSeconds(1);
		MainMenu.SetActive(false);
		levelsController.SetInteractable(true);
		LevelsMenu.SetActive(true);
	}

	public void OpenYouWin()
	{
		YouWinMenu.SetActive(true);
	}

	private IEnumerator OpenGameSceneCoroutine(int levelNumber)
	{
		levelsController.SetInteractable(false);
		yield return new WaitForSeconds(1);
		LevelsMenu.SetActive(false);
		GameScene.SetActive(true);
		gameController.LoadLevel(levelNumber);
		GameMenu.SetActive(true);
		MainMenuButton.interactable = true;
		GameOptionButton.interactable = true;
	}

	public void OpenOption()
	{
		OptionButton.interactable = false;
		PlayButton.interactable = false;
		MainMenuButton.interactable = false;
		GameOptionButton.interactable = false;
		Option.SetActive(true);
	}

	public void CloseOption() =>
		StartCoroutine(CloseOptionCoroutine());

	private IEnumerator CloseOptionCoroutine()
	{
		yield return new WaitForSeconds((float)0.3);

		OptionButton.interactable = true;
		PlayButton.interactable = true;
		MainMenuButton.interactable = true;
		GameOptionButton.interactable = true;
		Option.SetActive(false);
	}

	public void NextLevel()
	{
		YouWinMenu.SetActive(false);
		gameController.NextLevelLoad();
	}

	public void ReloadLeve()
	{
		TryAgain.SetActive(false);
		gameController.ReloadLevel();
	}
}