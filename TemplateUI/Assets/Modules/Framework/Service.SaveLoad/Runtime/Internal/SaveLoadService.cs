using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Service.SaveLoad.Runtime.Api;

namespace Service.SaveLoad.Runtime.Internal
{
	internal class SaveLoadService : ISaveLoadService
	{
		private readonly List<ISaveLoad> _saveLoadObjects;

		public SaveLoadService(IEnumerable<ISaveLoad> saveLoadObjects) =>
			_saveLoadObjects = new List<ISaveLoad>(saveLoadObjects);

		public void SaveAll() =>
			_saveLoadObjects.ForEach(saveLoadObject => saveLoadObject.Save());

		public async UniTask  LoadAll()
		{
			foreach (ISaveLoad saveLoadObject in _saveLoadObjects)
				await saveLoadObject.Load();
		}
	}
}