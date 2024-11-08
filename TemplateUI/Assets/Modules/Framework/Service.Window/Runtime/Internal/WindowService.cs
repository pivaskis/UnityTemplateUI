using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Service.Window.Runtime.Api;

namespace Service.Window.Runtime.Internal
{
	public class WindowService : IWindowService
	{
		private readonly IWindowFactory _windowFactory;
		private Dictionary<Type, IWindow> _windowByType = new();

		public WindowService(IWindowFactory windowFactory)
		{
			_windowFactory = windowFactory;
		}

		public async UniTask<TWindow> Show<TWindow>() where TWindow : ICommonWindow, new()
		{
			var window = _windowFactory.Create<TWindow>();

			Type typeWindow = typeof(TWindow);

			_windowByType.Add(typeWindow, window);

			await window.Initialize();
			await window.Show();
			return window;
		}

		public async UniTask Close<TWindow>() where TWindow : IWindow
		{
			Type typeWindow = typeof(TWindow);
			await _windowByType[typeWindow].Close();
			_windowByType.Remove(typeWindow);
		}

		public UniTask CloseAll()
		{
			foreach (IWindow window in _windowByType.Values) 
				window.Dispose();

			return UniTask.CompletedTask;
		}
	}
}