using System;
using UnityEngine;

namespace Modules.Framework.Service.WindowService.Runtime.Installer
{
	[Serializable]
	internal class WindowByType
	{
		[SerializeField] private string _type;
		[SerializeField] private GameObject _prefab;

		public string Type => _type;
		public GameObject Prefab => _prefab;

		public WindowByType(string type, GameObject prefab)
		{
			_type = type;
			_prefab = prefab;
		}
	}
}