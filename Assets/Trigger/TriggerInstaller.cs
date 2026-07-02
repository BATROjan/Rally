using Zenject;

namespace Trigger
{
    public class TriggerInstaller : Installer<TriggerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<TriggerConfig>()
                .FromScriptableObjectResource("TriggerConfig")
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<TriggerController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<TriggerView, TriggerView.Pool>()
                .FromComponentInNewPrefabResource("TriggerView");
        }
    }
}