using GameController;
using Grid;
using MainCamera;
using Player;
using UI;
using Zenject;

namespace Installer
{
    public class ApplicationInstaller : MonoInstaller<ApplicationInstaller>
    {
        public override void InstallBindings()
        {
            CameraInstaller
                .Install(Container);
            UIRootInstaller
                .Install(Container);
            GridInstaller.
                Install(Container);
            PlayerInstaller
                .Install(Container);
            Container
                .Bind<GameController.GameController>()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<GameConfig>()
                .FromScriptableObjectResource("GameConfig")
                .AsSingle()
                .NonLazy();
        }
    }
}