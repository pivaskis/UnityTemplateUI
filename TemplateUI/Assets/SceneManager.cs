using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
	public GameObject GameScene;
	public GameObject GameMenu;
	public GameObject MainMenu;
	public GameObject Option;

	public Button PlayButton;
	public Button OptionButton;
	public Button MainMenuButton;
	public Button GameOptionButton;

	public void OpenMainScene() => 
		StartCoroutine(OpenMainSceneCoroutine());

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

	public void OpenGameScene() => 
		StartCoroutine(OpenGameSceneCoroutine());

	private IEnumerator OpenGameSceneCoroutine()
	{
		PlayButton.interactable = false;
		OptionButton.interactable = false;
		yield return new WaitForSeconds(1);
		GameScene.SetActive(true);
		GameMenu.SetActive(true);
		MainMenu.SetActive(false);
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
}