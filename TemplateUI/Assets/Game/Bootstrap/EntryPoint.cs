using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.States;
using Service.StateMachine.Api;
using VContainer.Unity;

namespace Game.Bootstrap
{
	public class EntryPoint : IStartable, IDisposable
	{
		private readonly IStatesServiceInitializer _statesServiceInitializer;
		private readonly IStatesService _statesService;
		private readonly CancellationTokenSource _cancellationTokenSource;

		public EntryPoint(IStatesServiceInitializer statesServiceInitializer, IStatesService statesService)
		{
			_statesServiceInitializer = statesServiceInitializer;
			_statesService = statesService;
			_cancellationTokenSource = new CancellationTokenSource();
		}

		public void Start()
		{
			_statesServiceInitializer.Initialize();
			_statesService.EnterAsync<LoadingState>(_cancellationTokenSource.Token).Forget();
		}

		public void Dispose()
		{
			_cancellationTokenSource?.Cancel();
			_cancellationTokenSource?.Dispose();
		}
	}
}