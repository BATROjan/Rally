namespace Grid
{
    public class GridController
    {
        private readonly GridConfig _gridConfig;
        private readonly GridView.Pool _gridPool;

        public GridController(
            GridConfig gridConfig,
            GridView.Pool gridPool)
        {
            _gridConfig = gridConfig;
            _gridPool = gridPool;
        }
        
        public void SpawnGrid()
        {
            var grid = _gridPool.Spawn();
        }

        public GridModel GetGrid(int playerCount)
        {
            return _gridConfig.GetGrid(playerCount);
        }
    }
}