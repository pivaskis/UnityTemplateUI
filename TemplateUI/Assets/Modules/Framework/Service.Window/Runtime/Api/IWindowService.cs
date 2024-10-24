using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Service.Window.Runtime.Api
{
	[PublicAPI]
	public interface IWindowService
	{
		UniTask<TWindow> Show<TWindow>() where TWindow : ICommonWindow, new();
		UniTask Close<TWindow>() where TWindow : IWindow;
		UniTask CloseAll();
	}
}