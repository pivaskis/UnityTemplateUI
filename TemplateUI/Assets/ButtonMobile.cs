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

	public Button.ButtonClickedEvent MouseDown
	{
		get => m_OnMouseDown;
		set => m_OnMouseDown = value;
	}

	public Button.ButtonClickedEvent MouseEnter
	{
		get => m_OnMouseEnter;
		set => m_OnMouseEnter = value;
	}

	public Button.ButtonClickedEvent MouseExit
	{
		get => m_OnMouseExit;
		set => m_OnMouseExit = value;
	}

	public Button.ButtonClickedEvent MouseUpAsButton
	{
		get => m_OnMouseUpAsButton;
		set => m_OnMouseUpAsButton = value;
	}

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

		MouseDown?.Invoke();
		transform.localScale *= scaleMultiplier;
		_audioSource.Play();
	}

	private void OnMouseEnter()
	{
		if (CanNotExecute)
			return;

		MouseEnter?.Invoke();
	}

	private void OnMouseExit()
	{
		if (CanNotExecute)
			return;

		MouseExit?.Invoke();
		transform.localScale = _normalScale;
	}

	private void OnMouseUpAsButton()
	{
		if (CanNotExecute)
			return;

		MouseUpAsButton?.Invoke();
		transform.localScale = _normalScale;
	}
}