using UI;
using UI.GameUIWindow;
using UI.UISelectWindow;
using UI.UIStartWindow;
using UI.UIWinWindow;
using Zenject;

namespace UI
{
    public class UIRootInstaller : Installer<UIRootInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIRoot>()
                .FromComponentInNewPrefabResource("UIRoot")
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IUIService>()
                .To<UIService>()
                .AsSingle()
                .NonLazy();
            
            UIStartWindowInstaller.Install(Container);
            UISelecWindowInstaller.Install(Container);
            GameUIWindowInstaller.Install(Container);
            UIWinWindowInstaller.Install(Container);
        }
    }
}