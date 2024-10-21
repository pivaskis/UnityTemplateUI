using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenuController : MonoBehaviour
{
    public int ShipName;
    public Image IconImg;
    public TextMeshProUGUI PriceTxt;
    public Button BuyButton;

    public event Action<int> OnBought; 

    private void Awake()
    {
        BuyButton.onClick.AddListener(OnBuyButtonClicked);
    }

    public void SetShipData(Ball ball)
    {
        ShipName = ball.BallName;
        IconImg.sprite = ball.Icon;
        PriceTxt.text = ball.Price.ToString();
    } 

    private void OnEnable()
    {
    }

    private void OnBuyButtonClicked()
    {
        OnBought?.Invoke(ShipName);
    }
}
