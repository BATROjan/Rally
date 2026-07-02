using System;
using UnityEngine;

namespace Trigger
{
    [CreateAssetMenu(fileName = "TriggerConfig", menuName = "Configs/TriggerConfig")]
    
    public class TriggerConfig : ScriptableObject
    {
        
    }

    [Serializable]
    public struct TriggerModel
    {
        public Vector3 Rosition;
        public Vector3 Rotation;
        public Vector2 Size;
        public int Id;
    }
}