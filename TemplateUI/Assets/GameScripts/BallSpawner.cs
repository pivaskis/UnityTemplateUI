using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	public GameObject ball;
	public AudioSource audioSource;

	[ContextMenu("CreateBall")]
	public GameObject CreateBall()
	{
		GameObject createdBall = Instantiate(ball);
		createdBall.transform.position = transform.position;
		createdBall.SetActive(true);
		createdBall.GetComponent<Rigidbody2D>().sharedMaterial = PlayerController.instance.ball.physicsMaterial;
		createdBall.GetComponent<SpriteRenderer>().sprite = PlayerController.instance.ball.Skin;
		audioSource.Play();

		return createdBall;
	}
}