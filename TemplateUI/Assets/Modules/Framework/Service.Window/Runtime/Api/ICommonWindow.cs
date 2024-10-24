using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Service.Window.Runtime.Api
{
	[PublicAPI]
	public interface ICommonWindow : IWindow
	{
		UniTask Initialize();
	}
}