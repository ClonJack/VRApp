using _Project.Code.GamePlay.PlayerController;
using BNG;
using UnityEngine;

namespace _Project.Code.Services
{
    public class ObjectsProvider
    {
        public Transform SpawnPoint { get; set; }
        public PlayerBehaviour PlayerBehaviour { get; set; }
        public VRUISystem VrUISystem { get; set; }
    }
}