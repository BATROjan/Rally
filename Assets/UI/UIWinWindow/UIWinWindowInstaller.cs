using Zenject;

namespace UI.UIWinWindow
{
    public class UIWinWindowInstaller : Installer<UIWinWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UIWinWindowInstaller>()
                .AsSingle()
                .NonLazy();
        }
    }
}