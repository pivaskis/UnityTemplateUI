using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Box : MonoBehaviour
{
	public int Multipler=0;
	public TextMeshPro MultiplayerText;
	public AudioSource audioSource;
	public event Action<int> OnBallCollision;

	private void Awake() => 
		audioSource = transform.GetComponent<AudioSource>();

	private void Start() =>
		StartCoroutine(RandomizeMultiplier());

	private IEnumerator RandomizeMultiplier()
	{
	//	while (isActiveAndEnabled)
		{
			//Multipler = Random.Range(9, 41);
			MultiplayerText.text = $"X{Multipler}";
			yield return new WaitForSeconds(Random.Range(1, 3));
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(collision.gameObject.GetInstanceID()+" "+this.GetInstanceID());
		Destroy(collision.gameObject);
		OnBallCollision?.Invoke(Multipler);
		audioSource.Play();
	}
}