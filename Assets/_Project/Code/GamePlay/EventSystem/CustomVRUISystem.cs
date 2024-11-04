using BNG;
using UnityEngine;
using UnityEngine.EventSystems;
using UnrealTeam.VR.GamePlay.Behaviours;
using UnrealTeam.VR.Services.Input;
using VContainer;

namespace UnrealTeam.VR.GamePlay
{
    public class CustomVRUISystem : VRUISystem
    {
        private IInputService _inputService;
        
        
        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public override void Process()
        {
            if (_inputService.NavigatePress.IsPressed())
            {
                var vrKey = ReleasingObject.GetComponent<IInteract>(); 
                vrKey.DoInteract();
            }
            base.Process();
        }
        
        public void SetManuallyHover(GameObject newTarget, PointerEventData eventData = null)
        {
            HandlePointerExitAndEnter(EventData, newTarget);
            
            ReleasingObject = newTarget;
        }
    }
}