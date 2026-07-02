using System.Collections.Generic;
using UnityEngine;

namespace Trigger
{
    public class TriggerController
    {
        private readonly TriggerView.Pool _triggerPool;

        private List<TriggerView> _triggerViews= new ();
        TriggerController(
            TriggerView.Pool triggerPool)
        {
            _triggerPool = triggerPool;
        }

        public TriggerView Spawn(Transform parent, Vector2 pos, Vector3 rotation, Vector2 size, int id)
        {
           var view =  _triggerPool.Spawn(parent, pos, rotation, size, id);
           _triggerViews.Add(view);
           
           return view;
        }
    }
}