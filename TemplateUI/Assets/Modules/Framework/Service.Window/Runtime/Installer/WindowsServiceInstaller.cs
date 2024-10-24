using Service.Window.Runtime.Data;
using Service.Window.Runtime.Behaviours;
using Service.Window.Runtime.Internal;
using Tools.VContainer;
using UnityEngine;
using VContainer;

namespace Service.Window.Runtime.Installer
{
	[CreateAssetMenu(fileName = "WindowsServiceInstaller", menuName = "Modules/Installers/WindowsServiceInstaller")]
	public class WindowsServiceInstaller : ScriptableInstaller
	{
		[SerializeField] private RootWindowsBehaviour rootWindowsBehaviour;
		[SerializeField] private WindowsData windowsData;

		public override void InternalInstall(IContainerBuilder builder)
		{
			builder.Register<WindowFactory>(Lifetime.Scoped).WithParameter(windowsData);
			builder.Register<WindowService>(Lifetime.Scoped).AsImplementedInterfaces();
		}
	}
}