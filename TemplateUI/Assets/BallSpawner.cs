using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
	public GameObject ball;

	[ContextMenu("CreateBall")]
	public void CreateBall()
	{
		GameObject createdBall = Instantiate(ball, transform);
		var randomPosition = Random.insideUnitSphere;
		randomPosition.z = -1;
		createdBall.transform.localPosition = randomPosition;

		createdBall.SetActive(true);
	}

}