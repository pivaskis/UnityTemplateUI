using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Service.StateMachine.Api.States;

namespace Service.StateMachine.Api
{
    [PublicAPI]
    public interface IStatesService
    {
        UniTask EnterAsync<TState>(CancellationToken cancellationToken) where TState : class, IState;

        UniTask EnterAsync<TState, TPayload>(TPayload payload, CancellationToken cancellationToken)
            where TState : class, IPayloadState<TPayload>;
    }
}