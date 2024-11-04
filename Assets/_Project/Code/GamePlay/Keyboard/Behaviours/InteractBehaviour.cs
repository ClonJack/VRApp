using UnityEngine;
using UnityEngine.Events;

namespace UnrealTeam.VR.GamePlay.Behaviours
{
    public class InteractBehaviour : MonoBehaviour, IInteract
    {
        [SerializeField] 
        private UnityEvent _onInteract;

        
        public void DoInteract() =>
            _onInteract?.Invoke();
    }
}