using JetBrains.Annotations;

namespace Service.StateMachine.Api
{
    [PublicAPI]
    public interface IStatesServiceInitializer
    {
        void Initialize();
    }
}