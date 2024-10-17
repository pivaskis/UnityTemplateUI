using Modules.Framework.Service.WindowService.Runtime.Installer;
using Service.WindowService.Runtime.Api;
using VContainer;

namespace Modules.Framework.Service.WindowService.Runtime.Internal
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