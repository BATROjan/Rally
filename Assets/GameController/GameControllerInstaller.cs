using Zenject;

namespace GameController
{
    public class GameControllerInstaller : Installer<GameControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<GameController>()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<LapPartCounterController>()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<LapCounterController>()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<TimerController>()
                .AsSingle()
                .NonLazy();
        }
    }
}