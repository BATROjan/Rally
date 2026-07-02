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
            Container
                .BindMemoryPool<PlayerTooltipView, PlayerTooltipView.Pool>()
                .FromComponentInNewPrefabResource("PlayerTooltip");
            Container
                .Bind<PlayerTooltipConfig>()
                .FromScriptableObjectResource("PlayerTooltipConfig")
                .AsSingle()
                .NonLazy();
        }
    }
}