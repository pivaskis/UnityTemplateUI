using UnityEngine;
using UnityEngine.UI;

public class ButtonMobile : MonoBehaviour
{
	public bool IsInteractable = true;

	[SerializeField] private AudioClip clickSound;
	[SerializeField] private float scaleMultiplier = 1;
	[SerializeField] private Button.ButtonClickedEvent m_OnMouseDown = new Button.ButtonClickedEvent();
	[SerializeField] private Button.ButtonClickedEvent m_OnMouseEnter = new Button.ButtonClickedEvent();
	[SerializeField] private Button.ButtonClickedEvent m_OnMouseExit = new Button.ButtonClickedEvent();
	[SerializeField] private Button.ButtonClickedEvent m_OnMouseUpAsButton = new Button.ButtonClickedEvent();

	private AudioSource _audioSource;
	private Vector3 _normalScale;
	private bool CanNotExecute => !isActiveAndEnabled || !IsInteractable;

	private void Awake()
	{
		_normalScale = transform.localScale;

		ConfigureAudio();
	}

	private void ConfigureAudio()
	{
		_audioSource = gameObject.GetComponent<AudioSource>() == null
			? gameObject.AddComponent<AudioSource>()
			: gameObject.GetComponent<AudioSource>();

		_audioSource.playOnAwake = false;
		_audioSource.clip = clickSound;
	}

	private void OnMouseDown()
	{
		if (CanNotExecute)
			return;

		m_OnMouseDown?.Invoke();
		transform.localScale *= scaleMultiplier;
		_audioSource.Play();
	}

	private void OnMouseEnter()
	{
		if (CanNotExecute)
			return;

		m_OnMouseEnter?.Invoke();
	}

	private void OnMouseExit()
	{
		if (CanNotExecute)
			return;

		m_OnMouseExit?.Invoke();
		transform.localScale = _normalScale;
	}

	private void OnMouseUpAsButton()
	{
		if (CanNotExecute)
			return;

		m_OnMouseUpAsButton?.Invoke();
		transform.localScale = _normalScale;
	}
}