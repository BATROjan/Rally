
using UI;
using Zenject;
using Zenject.Asteroids;

namespace Installer
{
    public class ApplicationInstaller : MonoInstaller<ApplicationInstaller>
    {
        public override void InstallBindings()
        {
           /* CameraInstaller
                .CameraInstaller
                .Install(Container);*/

            UIRootInstaller
                .Install(Container);



 

         /*   Container
                .Bind<GameController.GameController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<GameConfig>()
                .FromScriptableObjectResource("GameConfig")
                .AsSingle()
                .NonLazy();*/
        }
    }
}