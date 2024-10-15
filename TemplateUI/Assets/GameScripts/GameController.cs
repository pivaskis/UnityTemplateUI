using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
	public BallSpawner ballSpawner;
	public TextMeshPro counterText;
	public LevelsConfig LevelsConfig;

	public BoxContainerController boxController;

	public int ballsCount;

	public int createdBallsCount = 0;

	public TextMeshProUGUI LevelTxt;
	public TextMeshProUGUI NeedFuelTxt;

	public event Action<bool> LevelComplete;

	private int _counter = 0;
	private int winnableScore;
	private IEnumerator spawnerCoroutine;
	private int currentLevelNumber;

	public Animation boxesAnimation;
	public Animation BallSpawnerAnimation;


	private void Start() =>
		boxController.MultiplayerCounter += MultiplayCounter;

	private IEnumerator BallSpawnerCoroutine()
	{
		yield return new WaitForSeconds(1);

		while (ballsCount != 0)
		{
			ballSpawner.CreateBall();
			yield return new WaitForSeconds(Random.Range(1, 3));
			createdBallsCount++;
			ballsCount--;
		}
	}

	public void NextLevelLoad() =>
		LoadLevel(currentLevelNumber + 1);

	public void LoadLevel(int levelNumber)
	{
		SetLevelConfig(levelNumber);
		_counter = 0;
		counterText.text = _counter.ToString();

		LevelTxt.text = "Level " + levelNumber;
		NeedFuelTxt.text = "Required fuel " + winnableScore;

		spawnerCoroutine = BallSpawnerCoroutine();
		StartCoroutine(spawnerCoroutine);
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
		}
		else if (ballsCount == 0 && createdBallsCount == 0)
		{
			TryAgain();
		}
	}

	private void TryAgain()
	{
		EnableAnimation(false);
		LevelComplete?.Invoke(false);
	}

	private void EnableAnimation(bool isEnabled)
	{
		if (isEnabled)
		{
			boxesAnimation.Play();
			BallSpawnerAnimation.Play();
		}
		else
		{
			boxesAnimation.Stop();
			BallSpawnerAnimation.Stop();
		}
	}

	private void YouWin()
	{
		StopCoroutine(spawnerCoroutine);
		int nextLevelNumber = currentLevelNumber + 1;
		PlayerPrefs.SetInt("level " + nextLevelNumber, 1);
		LevelComplete?.Invoke(true);
		EnableAnimation(false);
	}

	private void SetLevelConfig(int levelNumber)
	{
		LevelConfig config = LevelsConfig.Levels[levelNumber - 1];
		currentLevelNumber = config.levelNumber;
		ballsCount = config.ballsCount;
		winnableScore = config.winnableScore;
	}
}