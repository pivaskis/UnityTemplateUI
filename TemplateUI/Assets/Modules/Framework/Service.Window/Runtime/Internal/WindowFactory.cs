using System.Linq;
using Service.Window.Runtime.Data;
using Service.Window.Runtime.Api;
using Service.Window.Runtime.Behaviours;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Service.Window.Runtime.Internal
{
	internal class WindowFactory : IWindowFactory
	{
		private readonly IObjectResolver _objectResolver;
		private readonly WindowsData _windowsData;
		private readonly RootWindowsBehaviour _rootWindowsBehaviour;

		public WindowFactory(IObjectResolver objectResolver,
			WindowsData windowsData,
			RootWindowsBehaviour rootWindowsBehaviour)
		{
			_objectResolver = objectResolver;
			_windowsData = windowsData;
			_rootWindowsBehaviour = rootWindowsBehaviour;
		}

		public TWindow Create<TWindow>() where TWindow : IWindow, new()
		{
			WindowByType data = null;

			foreach (WindowByType windowData in _windowsData.WindowByTypes.Where(windowData => windowData.Type == typeof(TWindow).ToString()))
			{
				data = windowData;
			}

			Transform container = GetContainer(data.Prefab);

			return _objectResolver.Instantiate(data.Prefab, container).GetComponent<TWindow>();
		}

		private Transform GetContainer(GameObject prefab)
		{
			WindowType windowType = prefab.GetComponent<Api.Window>().Type;

			return _rootWindowsBehaviour.GetContainerByWindowType(windowType);
		}
	}
}