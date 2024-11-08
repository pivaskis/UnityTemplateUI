using Service.Window.Runtime.Api;
using Service.Window.Runtime.Data;
using Service.Window.Runtime.Behaviours;
using Service.Window.Runtime.Internal;
using Tools.VContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Service.Window.Runtime.Installer
{
	[CreateAssetMenu(fileName = "WindowsServiceInstaller", menuName = "Modules/Installers/WindowsServiceInstaller")]
	public class WindowsServiceInstaller : ScriptableInstaller
	{
		[SerializeField] private RootWindowsBehaviour rootWindowsBehaviour;
		[SerializeField] private WindowsData windowsData;

		public override void InternalInstall(IContainerBuilder builder)
		{
			builder.Register<IWindowService, WindowService>(Lifetime.Scoped).AsImplementedInterfaces();
			builder.Register<IWindowFactory, WindowFactory>(Lifetime.Scoped).WithParameter(windowsData);
			
			builder.RegisterComponentInNewPrefab(rootWindowsBehaviour, Lifetime.Singleton);
		}
	}
}