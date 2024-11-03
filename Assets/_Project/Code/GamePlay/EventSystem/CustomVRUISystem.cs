using _Project.Code.GamePlay.Keyboard.Behaviours;
using BNG;
using Common.Modules.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace _Project.Code.GamePlay.EventSystem
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
            if (_inputService.NavigateSelect.IsPressed())
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