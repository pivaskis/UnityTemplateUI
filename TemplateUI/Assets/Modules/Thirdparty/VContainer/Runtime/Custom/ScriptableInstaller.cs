using UnityEngine;
using VContainer;

namespace Playttention.Framework.Tools.VContainer
{
    public abstract class ScriptableInstaller : ScriptableObject
    {
        public abstract void InternalInstall(IContainerBuilder builder);
    }
}