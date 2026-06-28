namespace Grid
{
    public class GridController
    {
        private readonly GridView.Pool _gridPool;

        public GridController(
            GridView.Pool gridPool)
        {
            _gridPool = gridPool;
        }
        
        public void SpawnGrid()
        {
            var grid = _gridPool.Spawn();
        }
    }
}