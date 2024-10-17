using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Service.WindowService.Runtime.Api
{
	[PublicAPI]
	public interface IWindow : IDisposable
	{
		UniTask Show();
		UniTask Close();
	}
}