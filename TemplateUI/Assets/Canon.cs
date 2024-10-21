using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
	public ButtonMobile buttonPush;
	public float forceMultiplier = 100;

	[SerializeField] private float _defaultForceAmount = 6500;
	[SerializeField] private float _maxForceAmount = 12000;
	[SerializeField] private Slider slider;

	private float _forceAmount = 6500;
	private Rigidbody2D _pushingBallRigidbody;
	private IEnumerator _accumulatePowerCoroutine;
	private float _sliderDivisionPrice;


	private void Awake()
	{
		buttonPush.MouseDown.AddListener(OnMouseDown);
		buttonPush.MouseExit.AddListener(OnMouseExit);
		buttonPush.MouseUpAsButton.AddListener(OnMouseUpAsButton);

		buttonPush.IsInteractable = false;

		_accumulatePowerCoroutine = AccumulatePowerCoroutine();

		_forceAmount = _defaultForceAmount;

		_sliderDivisionPrice = (_maxForceAmount - _defaultForceAmount) / slider.maxValue;
	}

	public void SetPushingBall(GameObject ball)
	{
		_pushingBallRigidbody = ball.GetComponent<Rigidbody2D>();
		buttonPush.IsInteractable = true;
	}

	private void OnMouseDown()
	{
		_accumulatePowerCoroutine = AccumulatePowerCoroutine();
		StartCoroutine(_accumulatePowerCoroutine);
	}

	private IEnumerator AccumulatePowerCoroutine()
	{
		while (_forceAmount < _maxForceAmount)
		{
			yield return new WaitForSeconds((float)0.1);
			_forceAmount += forceMultiplier;
			UpdateSlider();
		}
	}

	private void OnMouseExit()
	{
		StopCoroutine(_accumulatePowerCoroutine);
		_forceAmount = _defaultForceAmount;
		UpdateSlider();
	}

	private void OnMouseUpAsButton()
	{
		StopCoroutine(_accumulatePowerCoroutine);

		PushBall();

		buttonPush.IsInteractable = false;
		_forceAmount = _defaultForceAmount;
		UpdateSlider();
	}

	private void PushBall()
	{
		_pushingBallRigidbody.bodyType = RigidbodyType2D.Dynamic;
		_pushingBallRigidbody.AddForce(Vector2.up * _forceAmount, ForceMode2D.Impulse);
		_pushingBallRigidbody = null;

		Debug.Log("PushBall _forceAmount = " + _forceAmount);
	}

	private void UpdateSlider() =>
		slider.value = (_forceAmount - _defaultForceAmount) / _sliderDivisionPrice;
}