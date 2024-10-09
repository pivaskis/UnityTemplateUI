using Service.StateMachine.Api.States;
using VContainer;

namespace Service.StateMachine.Internal
{
    internal class StatesFactory : IStatesFactory
    {
        private readonly IObjectResolver _resolver;
        
        public StatesFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public TState Create<TState>() where TState : IExitState
        {
            return _resolver.Resolve<TState>();
        }
    }
}