using Service.WindowService.Runtime.Api;

namespace Modules.Framework.Service.WindowService.Runtime.Internal
{
	public interface IWindowFactory
	{
		public TWindow Create<TWindow>() where TWindow : IWindow, new();
	}
}