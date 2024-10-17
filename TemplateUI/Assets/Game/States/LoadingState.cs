using System.Threading;
using Cysharp.Threading.Tasks;
using Service.WindowService.Runtime.Api;
using Service.StateMachine.Api;
using Service.StateMachine.Api.States;

namespace Game.States
{
	public class LoadingState : IState
	{
		private readonly IStatesService _statesService;
		private readonly IWindowService _windowService;

		public LoadingState(IStatesService statesService, IWindowService windowService)
		{
			_statesService = statesService;
			_windowService = windowService;
		}

		public async UniTask ExitAsync(CancellationToken cancellationToken)
		{
			await _windowService.Show<FaderWindow>();

			await _statesService.EnterAsync<MainState>(cancellationToken);
		}

		public async UniTask EnterAsync(CancellationToken cancellationToken)
		{
			await _windowService.Close<FaderWindow>();
		}
	}
}