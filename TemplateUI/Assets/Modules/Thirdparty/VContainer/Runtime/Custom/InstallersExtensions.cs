using VContainer;

namespace Tools.VContainer
{
    public static class InstallersExtensions
    {
        public static void Install(this MonoInstaller instance, IContainerBuilder builder)
        {
            instance.InternalInstall(builder);
        }
        
        public static void Install(this ScriptableInstaller instance, IContainerBuilder builder)
        {
            instance.InternalInstall(builder);
        }
    }
}