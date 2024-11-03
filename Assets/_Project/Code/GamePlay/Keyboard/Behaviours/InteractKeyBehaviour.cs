using BNG;
using UnityEngine;

namespace _Project.Code.GamePlay.Keyboard.Behaviours
{
    public class InteractKeyBehaviour : MonoBehaviour, IInteract
    {
        private VRKeyboardKey _keyboardKey;

        
        public void Awake() => 
            _keyboardKey = GetComponent<VRKeyboardKey>();
        
        public void DoInteract() =>
            _keyboardKey.OnKeyHit();
    }
}