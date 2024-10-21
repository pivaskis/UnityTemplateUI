using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public BallSpawner ballSpawner;
	public Canon canon;
	public TextMeshPro counterText;
	public LevelsConfig LevelsConfig;

	public BoxContainerController boxController;

	public int ballsCount;

	public int createdBallsCount = 0;

	public TextMeshProUGUI LevelTxt;
	public TextMeshProUGUI NeedFuelTxt;

	public GameObject levelsContainer;

	public event Action<bool, int> LevelComplete;

	private int _counter = 0;
	private int winnableScore;
	private int GameCoins;
	private int currentLevelNumber;

	public Animation boxesAnimation;
	private GameObject levelPrefab;
	private GameObject currentLevelPrefab;
	private GameObject createdBall;

	[ContextMenu("CreateBall")]
	private void CreateBall()
	{
		if (createdBall != null) 
			Destroy(createdBall);

		createdBall = ballSpawner.CreateBall();
		
		canon.SetPushingBall(createdBall);
		createdBallsCount++;
		ballsCount--;
	}

	public void NextLevelLoad()
	{
		LoadLevel(currentLevelNumber + 1);
		if (boxController != null)
		{
			boxController.MultiplayerCounter += MultiplayCounter;
		}
	}

	public void LoadLevel(int levelNumber)
	{
		ballsCount = PlayerController.instance.ballsCount;

		SetLevelConfig(levelNumber);
		_counter = 0;
		counterText.text = _counter.ToString();

		LevelTxt.text = "Level " + levelNumber;
		NeedFuelTxt.text = "Required fuel " + winnableScore;

		if (currentLevelPrefab!=null) 
			Destroy(currentLevelPrefab);

		currentLevelPrefab = Instantiate(levelPrefab, levelsContainer.transform);
		currentLevelPrefab.transform.localPosition = Vector3.zero;
		boxController = currentLevelPrefab.transform.GetChild(0).GetComponent<BoxContainerController>();
		boxController.MultiplayerCounter += MultiplayCounter;

		CreateBall();

		EnableAnimation(true);
	}

	public void ReloadLevel() =>
		LoadLevel(currentLevelNumber);

	private void MultiplayCounter(int multiplayer)
	{
		createdBallsCount--;
		_counter += multiplayer;
		counterText.text = _counter.ToString();
		if (_counter >= winnableScore)
		{
			YouWin();
			boxController.MultiplayerCounter -= MultiplayCounter;
		}
		else if (ballsCount == 0 && createdBallsCount == 0)
		{
			TryAgain();
		}
		else
		{
			CreateBall();
		}
	}

	private void TryAgain()
	{
		EnableAnimation(false);
		LevelComplete?.Invoke(false, 0);
	}

	private void EnableAnimation(bool isEnabled)
	{
		if (isEnabled)
		{
		}
		else
		{
		}
	}

	private void YouWin()
	{
		int nextLevelNumber = currentLevelNumber + 1;
		PlayerPrefs.SetInt("level " + nextLevelNumber, 1);
		LevelComplete?.Invoke(true, GameCoins);
		PlayerController.instance.GameCoins += GameCoins;
		EnableAnimation(false);
	}

	private void SetLevelConfig(int levelNumber)
	{
		LevelConfig config = LevelsConfig.Levels[levelNumber - 1];
		currentLevelNumber = config.levelNumber;
		winnableScore = config.winnableScore;
		GameCoins = config.LevelScore;
		levelPrefab = config.levelPrefab;
	}
}