using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipsConfig", menuName = "Game/Config/ShipsConfig")]
public class ShipsConfig : ScriptableObject
{
	public List<Ship> Ships;

	public Ship GetShipByName(int shipName) =>
		Ships.Count >= shipName 
			? Ships[shipName] 
			: Ships[0];
}