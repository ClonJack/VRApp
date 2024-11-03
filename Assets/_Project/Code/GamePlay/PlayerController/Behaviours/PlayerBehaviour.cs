using _Project.Code.Services;
using BNG;
using Common.Modules.Input;
using TriInspector;
using UnityEngine;
using VContainer;

namespace _Project.Code.GamePlay.PlayerController
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [field: Title("Ref"), SerializeField]
        public ScreenFader ScreenFader { get; private set; } 
        [field: SerializeField]
        public BNGPlayerController BngPlayerController { get; private set; }

        [SerializeField]
        private Transform _pointKeyboard;

        [SerializeField] 
        private GameObject _cameraCaster;
        

        private Quaternion _lastRotation;
        
        private IInputService _inputService;
        private ObjectsProvider _objectsProvider;
        
        
        [Inject]
        public void Construct(IInputService inputService, ObjectsProvider objectsProvider)
        {
            _inputService = inputService;
            _objectsProvider = objectsProvider;
        }

        public void Update()
        {
            UpdateKeyboardState();
            UpdateCameraCasterState();
        }

        private void UpdateKeyboardState()
        {
            if (_inputService.Keyboard.IsPressed())
                _objectsProvider.KeyboardBehaviour.UpdateKeyboardPosition(_pointKeyboard);
            
        }

        private  void UpdateCameraCasterState()
        {
            if (BngPlayerController== null || 
                _objectsProvider.VrUISystem.CameraCaster== null)
                return;
            
            if (_inputService.NavigateY.IsPressed()|| _inputService.NavigateX.IsPressed())
            {
                _objectsProvider.VrUISystem.CameraCaster.gameObject.SetActive(false);
                _objectsProvider.KeyboardBehaviour.UpdateNavigateKey();
            }

            if (BngPlayerController.transform.rotation != _lastRotation)
            {
                _objectsProvider.VrUISystem.CameraCaster.gameObject.SetActive(true);
                _lastRotation =  BngPlayerController.transform.rotation;
            }
          
        }
    }
}