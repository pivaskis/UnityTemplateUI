using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Service.SaveLoad.Runtime.Api
{
	[PublicAPI]
	public interface ISaveLoad
	{
		void Save();
		UniTask Load();
	}
}