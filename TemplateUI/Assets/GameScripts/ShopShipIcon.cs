using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopShipIcon : MonoBehaviour
{
	public int ShipName;
	public Image icon;
	public TextMeshProUGUI priceTxt;
	public int price;

	public event Action<int> OnShipIconSelected; 

	public void ShipIconSelected() => 
		OnShipIconSelected?.Invoke(ShipName);
}