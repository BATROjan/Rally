using Zenject;

namespace UI.UISelectWindow
{
    public class UISelecWindowInstaller : Installer<UISelecWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UISelectWindowController>()
                .AsSingle()
                .NonLazy();
        }
    }
}