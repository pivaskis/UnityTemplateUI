using System.Threading;
using Cysharp.Threading.Tasks;
using Service.StateMachine.Api.States;

namespace Game.States
{
	public class MainState:IState
	{
		public UniTask ExitAsync(CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public UniTask EnterAsync(CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}