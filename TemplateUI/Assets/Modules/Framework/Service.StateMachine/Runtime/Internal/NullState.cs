using System.Threading;
using Cysharp.Threading.Tasks;
using Service.StateMachine.Api.States;

namespace Service.StateMachine.Internal
{
    internal class NullState : IState
    {
        public UniTask EnterAsync(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }

        public UniTask ExitAsync(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}