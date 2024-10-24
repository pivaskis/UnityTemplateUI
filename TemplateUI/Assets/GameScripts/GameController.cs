using System;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private const string RequiredScore = "Required score ";
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

	public SpriteRenderer CurrentBallSkin;
	public TextMeshPro txtBallsAmount;

	public event Action<bool, int> LevelComplete;

	private int _scoreCounter = 0;
	private int winnableScore;
	private int GameCoins;
	private int currentLevelNumber;

	private GameObject levelPrefab;
	private GameObject currentLevelGameObject;
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

		UpdateBallSkinAndCount();
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
		_scoreCounter = 0;
		counterText.text = _scoreCounter.ToString();

		LevelTxt.text = "Level " + levelNumber;
		NeedFuelTxt.text = RequiredScore + winnableScore;

		if (currentLevelGameObject != null)
		{
			currentLevelGameObject.transform.GetChild(0).GetComponent<BoxContainerController>().MultiplayerCounter -= MultiplayCounter;
			Destroy(currentLevelGameObject);
		}

		currentLevelGameObject = Instantiate(levelPrefab, levelsContainer.transform);
		currentLevelGameObject.transform.localPosition = Vector3.zero;
		currentLevelGameObject.transform.GetChild(0).GetComponent<BoxContainerController>().MultiplayerCounter += MultiplayCounter;

		BonusController[] bonuses = currentLevelGameObject.GetComponentsInChildren<BonusController>();
		
		foreach (BonusController bonusController in bonuses) 
			bonusController.OnBonusReceived += BonusReceived;

		CreateBall();
	}

	private void BonusReceived(Bonus bonus)
	{
		switch (bonus)
		{
			case Bonus.Ball:
				ballsCount++;
				break;
			case Bonus.Coins:
				PlayerController.instance.ChangeCoinsCount(5);
				break;
			case Bonus.Score:
				_scoreCounter *= 2;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(bonus), bonus, null);
		}
	}

	public void ReloadLevel() =>
		LoadLevel(currentLevelNumber);

	private void UpdateBallSkinAndCount()
	{
		CurrentBallSkin.sprite = PlayerController.instance.ball.Skin;
		txtBallsAmount.text = ballsCount.ToString();
	}

	private void MultiplayCounter(int multiplayer)
	{
		createdBallsCount--;
		_scoreCounter += multiplayer;
		counterText.text = _scoreCounter.ToString();
		if (_scoreCounter >= winnableScore)
		{
			YouWin();
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

	private void TryAgain() =>
		LevelComplete?.Invoke(false, 0);

	private void YouWin()
	{
		int nextLevelNumber = currentLevelNumber + 1;
		PlayerPrefs.SetInt("level " + nextLevelNumber, 1);
		LevelComplete?.Invoke(true, GameCoins);
		PlayerController.instance.ChangeCoinsCount(GameCoins);
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