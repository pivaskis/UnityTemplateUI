using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Collider2D))]
public class BonusController : MonoBehaviour
{
	public event Action<Bonus> OnBonusReceived;


	[SerializeField] private TextMeshPro bonusTxt;
	[SerializeField] private AudioClip bonusReceivedSound;
	[SerializeField] private Ease _ease;

	private Bonus _bonusType;
	private SpriteRenderer _sprite;
	private Collider2D _collider;
	private AudioSource _audioSource;


	private void Awake()
	{
		_sprite = transform.GetComponent<SpriteRenderer>();
		_collider = transform.GetComponent<Collider2D>();
		_audioSource = transform.GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		_sprite.enabled = false;
		_collider.enabled = false;

		bonusTxt.gameObject.SetActive(true);
		Vector3 endValue = Vector3.one * 3;
		bonusTxt.transform.DOScale(endValue, 2).SetEase(_ease);
		bonusTxt.transform
			.DOMoveY(bonusTxt.transform.localPosition.y + 300, 2)
			.OnComplete(() => bonusTxt.gameObject.SetActive(false));
		_audioSource.clip = bonusReceivedSound;
		_audioSource.Play();

		_bonusType = RandomBonusRecived();
		string bonusText;

		switch (_bonusType)
		{
			case Bonus.Ball:
				bonusText = "You received bonus \n +1 ball";
				break;
			case Bonus.Coins:
				bonusText = "You received bonus \n +5 coins";
				break;
			case Bonus.Score:
				bonusText = "You received bonus \n score x2";
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}


		bonusTxt.text = bonusText;
	}


	private Bonus RandomBonusRecived()
	{
		Array values = Enum.GetValues(typeof(Bonus));
		var random = new Random();
		var bonus = (Bonus)values.GetValue(random.Next(values.Length));

		OnBonusReceived?.Invoke(bonus);
		return bonus;
	}
}

public enum Bonus
{
	Ball = 0,
	Coins = 1,
	Score = 2
}