using System;
using Service.Window.Runtime.Data;
using UnityEngine;

namespace Service.Window.Runtime.Behaviours
{
	internal class RootWindowsBehaviour : MonoBehaviour
	{
		
		[SerializeField] private Transform popup;
		[SerializeField] private Transform fullScreen;

		public Transform GetContainerByWindowType(WindowType windowType)
		{
			switch (windowType)
			{
				case WindowType.Fullscreen:
					return fullScreen;
				case WindowType.Popup:
					return popup;
				default:
					throw new ArgumentOutOfRangeException(nameof(windowType), windowType, null);
			}
		}
	}
}