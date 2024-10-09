using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Service.Logger.Api;
using Service.StateMachine.Api;
using Service.StateMachine.Api.States;

namespace Service.StateMachine.Internal
{
    internal class StatesService : IStatesService, IStatesServiceInitializer
    {
        private const string LogTag = "[StatesService]";

        private readonly IStatesFactory _statesFactory;
        private readonly ILoggerService _loggerService;

        private IExitState _activeState;
        private Type _activeStateType;

        public StatesService(IStatesFactory statesFactory, ILoggerService loggerService)
        {
            _statesFactory = statesFactory;
            _loggerService = loggerService;
        }

        public void Initialize()
        {
            _activeState = _statesFactory.Create<NullState>();
            _activeStateType = typeof(NullState);
        }
        
        public async UniTask EnterAsync<TState>(CancellationToken cancellationToken) where TState : class, IState
        {
            await ChangeState<TState>(cancellationToken);
        }

        public async UniTask EnterAsync<TState, TPayload>(TPayload payload, CancellationToken cancellationToken)
            where TState : class, IPayloadState<TPayload>
        {
            await ChangeState<TState, TPayload>(payload, cancellationToken);
        }

        private async UniTask ChangeState<TState>(CancellationToken cancellationToken) where TState : class, IState
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            
            var nextStateType = typeof(TState);
            
            _loggerService.Log(LogTag, $"Change state to the {nextStateType}");
            
            await _activeState.ExitAsync(cancellationToken);
            _loggerService.Log(LogTag, $"Exit from previous state {_activeStateType}");
            
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            
            var state = _statesFactory.Create<TState>();
            _loggerService.Log(LogTag, $"Factory created state {nextStateType}");
            
            _activeState = state;
            _activeStateType = nextStateType;
            
            _loggerService.Log(LogTag, $"Entering to the {nextStateType}");
            await state.EnterAsync(cancellationToken);
        }

        private async UniTask ChangeState<TState, TPayload>(TPayload payload, CancellationToken cancellationToken)
            where TState : class, IPayloadState<TPayload>
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            
            var nextStateType = typeof(TState);
            
            _loggerService.Log(LogTag, $"Change state to the {nextStateType} with the payload : {typeof(TPayload)}");

            await _activeState.ExitAsync(cancellationToken);
            _loggerService.Log(LogTag, $"Exit from previous state {_activeStateType}");

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var state = _statesFactory.Create<TState>();
            _loggerService.Log(LogTag, $"Factory created state {nextStateType}");
            
            _activeState = state;
            _activeStateType = nextStateType;
            
            _loggerService.Log(LogTag, $"Entering to the {nextStateType}");
            await state.EnterAsync(payload, cancellationToken);
        }
    }
}