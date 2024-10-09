using VContainer;

namespace Tools.VContainer
{
    public abstract class Installer<T> where T: Installer<T>, new()
    {
        protected abstract void InternalInstall(IContainerBuilder builder);

        public static void Install(IContainerBuilder builder)
        {
            var instance = new T();
            
            instance.InternalInstall(builder);
        }
    }
}