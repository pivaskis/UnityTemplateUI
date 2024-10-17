using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Service.StateMachine.Api.States
{
	[PublicAPI]
	public interface IPayloadState<in TPayload> : IExitState
	{
		UniTask EnterAsync(TPayload payload, CancellationToken cancellationToken);
	}
}