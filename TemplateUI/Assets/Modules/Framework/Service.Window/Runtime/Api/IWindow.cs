using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Service.Window.Runtime.Api
{
	[PublicAPI]
	public interface IWindow : IDisposable
	{
		UniTask Show();
		UniTask Close();
	}
}