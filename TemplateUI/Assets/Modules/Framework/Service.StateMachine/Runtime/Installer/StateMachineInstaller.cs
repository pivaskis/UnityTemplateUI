using Service.StateMachine.Internal;
using Tools.VContainer;
using UnityEngine;
using VContainer;

namespace Service.StateMachine.Installer
{
	[CreateAssetMenu(fileName = "StateMachineInstaller", menuName = "Modules/Installers/StateMachineInstaller")]
	public class StateMachineInstaller : ScriptableInstaller
	{
		public override void InternalInstall(IContainerBuilder builder)
		{
			builder.Register<IStatesFactory, StatesFactory>(Lifetime.Singleton);
			builder.Register<StatesService>(Lifetime.Singleton).AsImplementedInterfaces();

			builder.Register<NullState>(Lifetime.Transient);
		}
	}
}