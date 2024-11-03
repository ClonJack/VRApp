using UnityEngine;
using UnityEngine.Events;

namespace _Project.Code.GamePlay.Keyboard.Behaviours
{
    public class InteractBehaviour : MonoBehaviour, IInteract
    {
        [SerializeField] 
        private UnityEvent _onInteract;

        
        public void DoInteract() =>
            _onInteract?.Invoke();
    }
}