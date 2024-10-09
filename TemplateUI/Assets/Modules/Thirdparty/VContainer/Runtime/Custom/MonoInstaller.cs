using UnityEngine;
using VContainer;

namespace Playttention.Framework.Tools.VContainer
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void InternalInstall(IContainerBuilder builder);
    }
}