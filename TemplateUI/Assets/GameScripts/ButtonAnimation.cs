using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
	public Animation Animation;
	public AudioSource AudioSource;

	private void Awake()
	{
		Animation = transform.GetComponent<Animation>();
		AudioSource = transform.GetComponent<AudioSource>();
	}

	public void OnButtonPressed()
	{
		Animation.Play();
		AudioSource.Play();
	}
}