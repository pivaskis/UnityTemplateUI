using Service.StateMachine.Api.States;

namespace Service.StateMachine.Internal
{
    internal interface IStatesFactory
    {
        TState Create<TState>() where TState : IExitState;
    }
}