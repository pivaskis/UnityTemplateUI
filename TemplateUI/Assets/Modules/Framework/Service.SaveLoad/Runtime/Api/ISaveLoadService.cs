using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Service.SaveLoad.Runtime.Api
{
	[PublicAPI]
	public interface ISaveLoadService
	{
		void SaveAll();
		UniTask LoadAll();
	}
}