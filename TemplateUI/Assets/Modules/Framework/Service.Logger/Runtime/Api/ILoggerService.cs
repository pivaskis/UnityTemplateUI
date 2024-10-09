using JetBrains.Annotations;

namespace Service.Logger.Api
{
	[PublicAPI]
	public interface ILoggerService
	{
		void Log(string message);
		void LogWarning(string message);
		void LogError(string message);
		
		void Log(string logTag, string message);
		void LogWarning(string logTag, string message);
		void LogError(string logTag, string message);
	}
}