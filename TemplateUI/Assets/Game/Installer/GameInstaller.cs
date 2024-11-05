using Game.Bootstrap;
using Game.States.Installer;
using Tools.VContainer;
using VContainer;
using VContainer.Unity;

namespace Game.Installer
{
	public class GameInstaller : MonoInstaller
	{
		public override void InternalInstall(IContainerBuilder builder)
		{
			StatesInstaller.Install(builder);

			builder.RegisterEntryPoint<EntryPoint>();
		}
	}
}