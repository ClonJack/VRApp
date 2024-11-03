using UnityEngine;

namespace _Project.Code.GamePlay.Keyboard.Behaviours
{
    public class KeyboardBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Vector3 offset;
        
        
        public void UpdatePosition(Transform target)
        {
            var worldPosition = target.TransformPoint(offset);
            
            transform.position = worldPosition;
            transform.rotation = target.rotation;
        }
    }
}