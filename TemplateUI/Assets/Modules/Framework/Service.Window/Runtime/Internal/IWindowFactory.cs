using Service.Window.Runtime.Api;

namespace Service.Window.Runtime.Internal
{
	public interface IWindowFactory
	{
		public TWindow Create<TWindow>() where TWindow : IWindow, new();
	}
}