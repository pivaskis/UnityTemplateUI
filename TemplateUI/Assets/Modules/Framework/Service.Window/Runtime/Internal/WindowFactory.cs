using System.Linq;
using Service.Window.Runtime.Data;
using Service.Window.Runtime.Api;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Service.Window.Runtime.Internal
{
	internal class WindowFactory : IWindowFactory
	{
		private readonly IObjectResolver _objectResolver;
		private readonly WindowsData _windowsData;

		public WindowFactory(IObjectResolver objectResolver, WindowsData windowsData)
		{
			_objectResolver = objectResolver;
			_windowsData = windowsData;
		}

		public TWindow Create<TWindow>() where TWindow : IWindow, new()
		{
			GameObject window = null;

			foreach (WindowByType windowData in _windowsData.WindowByTypes.Where(windowData => windowData.Type == typeof(TWindow).ToString())) 
				window = _objectResolver.Instantiate(windowData.Prefab);

			return window!.GetComponent<TWindow>();
		}
	}
}