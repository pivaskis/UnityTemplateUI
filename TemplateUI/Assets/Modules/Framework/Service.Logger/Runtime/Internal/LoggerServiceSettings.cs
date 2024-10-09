using System;
using UnityEngine;

namespace Service.Logger.Internal
{
    [Serializable]
    internal class LoggerServiceSettings
    {
        [SerializeField] private bool isLogging;
        
        public bool IsLogging
        {
            get
            {
#if DEVELOPMENT_BUILD || UNITY_EDITOR
                return isLogging;
#else
                return false;
#endif
            }
        }
    }
}