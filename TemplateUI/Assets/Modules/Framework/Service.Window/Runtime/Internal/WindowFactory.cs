using Service.Window.Runtime.Data;
using Service.Window.Runtime.Api;
using Service.Window.Runtime.Installer;
using VContainer;

namespace Service.Window.Runtime.Internal
{
	internal class WindowFactory : IWindowFactory
	{
		private readonly IObjectResolver _objectResolver;
		private readonly WindowsData _windowsData;

		public WindowFactory(IObjectResolver objectResolver,WindowsData windowsData)
		{
			_objectResolver = objectResolver;
			_windowsData = windowsData;
		}
		
		public TWindow Create<TWindow>() where TWindow : IWindow, new()
		{
			throw new System.NotImplementedException();
		}
	}
}