using Modules.Framework.Service.WindowService.Runtime.Internal;
using Service.WindowService.Runtime.Api;
using Tools.VContainer;
using UnityEngine;
using VContainer;

namespace Modules.Framework.Service.WindowService.Runtime.Installer
{
	public class WindowsServiceInstaller : ScriptableInstaller
	{
		[SerializeField] private RootWindowsBehaviour rootWindowsBehaviour;
		[SerializeField] private WindowsData windowsData;

		public override void InternalInstall(IContainerBuilder builder)
		{
			builder.Register<IWindowFactory>(Lifetime.Scoped).WithParameter(windowsData);
			builder.Register<IWindowService>(Lifetime.Scoped).AsImplementedInterfaces();
		}
	}
}