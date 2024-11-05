using Tools.VContainer;
using VContainer;

namespace Game.States.Installer
{
	public class StatesInstaller : Installer<StatesInstaller>
	{
		protected override void InternalInstall(IContainerBuilder builder)
		{
			builder.Register<LoadingState>(Lifetime.Transient);
			builder.Register<MainState>(Lifetime.Transient);
		}
	}
}