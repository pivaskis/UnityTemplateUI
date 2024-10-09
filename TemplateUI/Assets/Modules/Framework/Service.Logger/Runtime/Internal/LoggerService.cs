using Service.Logger.Api;
using UnityEngine;

namespace Service.Logger.Internal
{
	internal class LoggerService : ILoggerService
	{
		private readonly LoggerServiceSettings _settings;
		
		public LoggerService(LoggerServiceSettings settings)
		{
			_settings = settings;
		}

		public void Log(string message)
		{
			if (!_settings.IsLogging)
			{
				return;
			}
			
			Debug.Log(message);
		}

		public void LogWarning(string message)
		{
			if (!_settings.IsLogging)
			{
				return;
			}
			
			Debug.LogWarning(message);
		}

		public void LogError(string message)
		{
			if (!_settings.IsLogging)
			{
				return;
			}
			
			Debug.LogError(message);
		}

		public void Log(string logTag, string message)
		{
			if (!_settings.IsLogging)
			{
				return;
			}
			
			Debug.Log($"<color=#00D956>{logTag}</color> {message}");
		}

		public void LogWarning(string logTag, string message)
		{
			if (!_settings.IsLogging)
			{
				return;
			}
			
			Debug.LogWarning($"<color=#C1C300>{logTag}</color> {message}");
		}

		public void LogError(string logTag, string message)
		{
			if (!_settings.IsLogging)
			{
				return;
			}
			
			Debug.LogError($"<color=#E55600>{logTag}</color> {message}");
		}
	}
}