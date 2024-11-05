using Cysharp.Threading.Tasks;
using Service.Window.Runtime.Api;

namespace Game.States
{
	public class FaderWindow : Window, ICommonWindow
	{
		public void Dispose()
		{
			
		}

		public UniTask Initialize()
		{
			return UniTask.CompletedTask;
		}

		public UniTask Show()
		{
			return UniTask.CompletedTask;
		}

		public UniTask Close()
		{
			return UniTask.CompletedTask;
		}
	}
}