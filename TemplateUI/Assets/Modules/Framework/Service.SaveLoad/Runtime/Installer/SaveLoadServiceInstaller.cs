using Service.SaveLoad.Runtime.Api;
using Service.SaveLoad.Runtime.Internal;
using Tools.VContainer;
using UnityEngine;
using VContainer;

namespace Service.SaveLoad.Runtime.Installer
{
	[CreateAssetMenu(fileName = "SaveLoadServiceInstaller", menuName = "Modules/Installers/SaveLoadServiceInstaller")]
	public class SaveLoadServiceInstaller:ScriptableInstaller
	{
		public override void InternalInstall(IContainerBuilder builder) => 
			builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
	}
}