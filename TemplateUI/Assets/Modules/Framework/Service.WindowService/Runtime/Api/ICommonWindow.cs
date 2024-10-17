using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Service.WindowService.Runtime.Api
{
	[PublicAPI]
	public interface ICommonWindow : IWindow
	{
		UniTask Initialize();
	}
}