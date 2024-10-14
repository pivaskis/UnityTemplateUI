using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Box : MonoBehaviour
{
	public int Multipler;
	public TextMeshPro MultiplayerText;
	public event Action<int> OnBallCollision;

	private void Start() =>
		StartCoroutine(RandomizeMultipler());

	private IEnumerator RandomizeMultipler()
	{
		while (isActiveAndEnabled)
		{
			Multipler = Random.Range(9, 41);
			MultiplayerText.text = $"X{Multipler}";
			yield return new WaitForSeconds(Random.Range(1, 3));
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(collision.gameObject);
		OnBallCollision?.Invoke(Multipler);
	}
}