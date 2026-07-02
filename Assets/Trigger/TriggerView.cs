using UnityEngine;
using Zenject;

namespace Trigger
{
    public class TriggerView : MonoBehaviour
    {
        [SerializeField] private Transform triggerTransform;
        [SerializeField] private BoxCollider2D boxCollider2D;
        
        public int _id;

        public int GetID()
        {
            return _id;
        }
        
        private void ReInit(Transform parent, Vector2 pos,Vector3 rotation, Vector2 size, int id)
        {
            triggerTransform.position = pos;
            var quaternion = triggerTransform.rotation;
            quaternion.eulerAngles = rotation;
            triggerTransform.rotation = quaternion;
            
            boxCollider2D.size = size;
            triggerTransform.SetParent(parent);
            _id = id;
        }
        
        public class Pool : MemoryPool<Transform, Vector2, Vector3,Vector2, int,TriggerView>
        {
            protected override void Reinitialize(Transform parent,Vector2 pos,Vector3 rotation, Vector2 size, int id,TriggerView view)
            {
                base.Reinitialize(parent,pos, rotation, size, id, view);
                view.ReInit(parent, pos, rotation, size, id);
            }
        }
    }
}