using System.Collections.Generic;
using Service.WindowService.Runtime.Api;
using UnityEngine;

namespace Modules.Framework.Service.WindowService.Runtime.Installer
{
	[CreateAssetMenu(menuName = "Modules/AssetData/WindowsData", fileName = "WindowsData", order = 0)]
	internal class WindowsData : ScriptableObject
	{
		[SerializeField] private List<WindowByType> _windowByTypes;

		public List<WindowByType> WindowByTypes => _windowByTypes;

		[ContextMenu("UpdateWindowDataTypes")]
		private void UpdateWindowDataTypes()
		{
			List<WindowByType> data = new List<WindowByType>();

			foreach (WindowByType windowData in _windowByTypes)
			{
				IWindow component = windowData.Prefab.GetComponent<IWindow>();
				data.Add(new WindowByType(component.GetType().ToString(), windowData.Prefab));
			}

			_windowByTypes = data;
		}
	}
}