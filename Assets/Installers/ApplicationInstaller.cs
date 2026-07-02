using GameController;
using Grid;
using MainCamera;
using Player;
using Trigger;
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
            TriggerInstaller
                .Install(Container);
            GameControllerInstaller
                .Install(Container);
            
            Container
                .Bind<GameConfig>()
                .FromScriptableObjectResource("GameConfig")
                .AsSingle()
                .NonLazy();
        }
    }
}