using System.Threading;
using Cysharp.Threading.Tasks;
using Service.Logger.Api;
using Service.SaveLoad.Runtime.Api;
using Service.Window.Runtime.Api;
using Service.StateMachine.Api;
using Service.StateMachine.Api.States;

namespace Game.States
{
	public class LoadingState : IState
	{
		private const string LOGTag = "LoadingState";

		private readonly IStatesService _statesService;
		private readonly ISaveLoadService _saveLoadService;
		private readonly IWindowService _windowService;
		private readonly ILoggerService _loggerService;

		public LoadingState(ILoggerService loggerService,
			IWindowService windowService,
			IStatesService statesService,
			ISaveLoadService saveLoadService)
		{
			_loggerService = loggerService;
			_windowService = windowService;
			_statesService = statesService;
			_saveLoadService = saveLoadService;
		}

		public async UniTask EnterAsync(CancellationToken cancellationToken)
		{
			_loggerService.Log(LOGTag, "EnterAsync");
			await _windowService.Show<FaderWindow>();
			await _saveLoadService.LoadAll();
		}

		public async UniTask ExitAsync(CancellationToken cancellationToken)
		{
			_loggerService.Log(LOGTag, "ExitAsync");
		}
	}
}