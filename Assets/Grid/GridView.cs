using UnityEngine;
using Zenject;

namespace Grid
{
    public class GridView : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<GridView>
        {
            protected override void Reinitialize(GridView item)
            {
                base.Reinitialize(item);
            }
        }
    }
}