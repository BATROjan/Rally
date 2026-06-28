using Zenject;

namespace UI.GameUIWindow
{
    public class GameUIWindowInstaller : Installer<GameUIWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<GameUIWindowController>()
                .AsSingle()
                .NonLazy();
        }
    }
}