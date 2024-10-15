using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	public GameObject ball;
	public AudioSource audioSource;

	[ContextMenu("CreateBall")]
	public void CreateBall()
	{
		GameObject createdBall = Instantiate(ball);
		createdBall.transform.position = transform.position;
		createdBall.SetActive(true);
		audioSource.Play();
	}
}