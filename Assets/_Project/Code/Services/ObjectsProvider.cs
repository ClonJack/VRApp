using _Project.Code.GamePlay.EventSystem;
using _Project.Code.GamePlay.Keyboard.Behaviours;
using _Project.Code.GamePlay.PlayerController;
using UnityEngine;

namespace _Project.Code.Services
{
    public class ObjectsProvider
    {
        public Transform SpawnPoint { get; set; }
        public PlayerBehaviour PlayerBehaviour { get; set; }
        public CustomVRUISystem VrUISystem { get; set; }
        public KeyboardBehaviour KeyboardBehaviour { get; set; }
    }
}