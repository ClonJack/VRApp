﻿using UnityEngine;
using UnrealTeam.VR.GamePlay;
using UnrealTeam.VR.GamePlay.Behaviours;

namespace UnrealTeam.VR.Services
{
    public class ObjectsProvider
    {
        public Transform SpawnPoint { get; set; }
        public PlayerBehaviour PlayerBehaviour { get; set; }
        public CustomVRUISystem VrUISystem { get; set; }
        public KeyboardBehaviour KeyboardBehaviour { get; set; }
    }
}