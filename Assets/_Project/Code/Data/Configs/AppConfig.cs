﻿using TriInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnrealTeam.Common.Modules.Configs;

namespace UnrealTeam.VR.Data.Configs
{
    [HideMonoScript]
    [DeclareBoxGroup("Scenes")]
    [DeclareBoxGroup("Configs")]
    [DeclareBoxGroup("Settings")]
    [CreateAssetMenu(menuName = "Configs/App", fileName = nameof(AppConfig), order = 50)]
    public class AppConfig : SoSingleConfig
    {
        [field: GroupNext("Scenes")]
        [field: SerializeField, Scene]
        public string LoadScene { get; private set; }


        [field: GroupNext("Settings")]
        [field: SerializeField]
        public int TargetFrameRate { get; private set; } = 60;
        
        
        [field: GroupNext("Configs")] 
        [field: SerializeField]
        public AssetReferenceT<PlayerConfig> PlayerConfig { get; private set; }
    }
}