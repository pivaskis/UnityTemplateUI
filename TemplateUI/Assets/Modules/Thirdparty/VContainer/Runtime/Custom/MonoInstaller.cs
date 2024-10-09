using UnityEngine;
using VContainer;

namespace Tools.VContainer
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void InternalInstall(IContainerBuilder builder);
    }
}