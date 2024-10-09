using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Service.StateMachine.Api.States
{
    [PublicAPI]
    public interface IExitState
    {
        UniTask ExitAsync(CancellationToken cancellationToken);
    }
}