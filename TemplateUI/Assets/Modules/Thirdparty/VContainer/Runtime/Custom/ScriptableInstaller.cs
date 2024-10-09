using UnityEngine;
using VContainer;

namespace Tools.VContainer
{
    public abstract class ScriptableInstaller : ScriptableObject
    {
        public abstract void InternalInstall(IContainerBuilder builder);
    }
}