using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tools.VContainer
{
    public class AdvancedLifetimeScope : LifetimeScope
    {
        [SerializeField] private ScriptableInstaller[] scriptableInstallers;
        [SerializeField] private MonoInstaller[] monoInstallers;

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var scriptableInstaller in scriptableInstallers)
            {
                scriptableInstaller.Install(builder);
            }
            
            foreach (var monoInstaller in monoInstallers)
            {
                monoInstaller.Install(builder);
            }
        }
    }
}