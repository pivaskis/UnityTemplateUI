using Service.Logger.Api;
using Service.Logger.Internal;
using Tools.VContainer;
using UnityEngine;
using VContainer;

namespace Service.Logger.Installer
{
	[CreateAssetMenu(fileName = "LoggerServiceInstaller", menuName = "Modules/Installers/LoggerServiceInstaller")]
	public class LoggerServiceInstaller : ScriptableInstaller
	{
		[SerializeField] private LoggerServiceSettings settings;
		
		public override void InternalInstall(IContainerBuilder builder)
		{
			builder.RegisterInstance(settings);
			builder.Register<ILoggerService, LoggerService>(Lifetime.Singleton);
		}
	}
}