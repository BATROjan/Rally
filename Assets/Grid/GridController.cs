using Trigger;

namespace Grid
{
    public class GridController
    {
        private readonly TriggerController _triggerController;
        private readonly GridConfig _gridConfig;
        private readonly GridView.Pool _gridPool;

        public GridController(
            TriggerController triggerController,
            GridConfig gridConfig,
            GridView.Pool gridPool)
        {
            _triggerController = triggerController;
            _gridConfig = gridConfig;
            _gridPool = gridPool;
        }
        
        public void SpawnGrid()
        {
            var grid = _gridPool.Spawn();
            foreach (var model in _gridConfig.GetGrid(0).TriggerModels)
            {
                _triggerController.Spawn(grid.TriggersParent, model.Rosition, model.Rotation, model.Size, model.Id);
            }
        }

        public GridModel GetGrid(int playerCount)
        {
            return _gridConfig.GetGrid(playerCount);
        }
    }
}