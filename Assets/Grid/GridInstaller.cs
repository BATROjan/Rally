using Zenject;

namespace Grid
{
    public class GridInstaller : Installer<GridInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<GridConfig>()
                .FromScriptableObjectResource("GridConfig")
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<GridController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<GridView, GridView.Pool>()
                .FromComponentInNewPrefabResource("GridView");
        }
    }
}