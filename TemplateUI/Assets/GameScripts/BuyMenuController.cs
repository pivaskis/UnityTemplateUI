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

    public void SetShipData(Ship ship)
    {
        ShipName = ship.ShipName;
        IconImg.sprite = ship.Icon;
        PriceTxt.text = ship.Price.ToString();
    } 

    private void OnEnable()
    {
    }

    private void OnBuyButtonClicked()
    {
        OnBought?.Invoke(ShipName);
    }
}
