using TriInspector;
using UnityEngine;
using UnrealTeam.Common.Configs;

namespace Data.Configs
{
    [HideMonoScript]
    [DeclareBoxGroup("Scenes")]
    [DeclareBoxGroup("Configs")]
    [DeclareBoxGroup("Layers")]
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
        
        
        [field: GroupNext("Layers")]
        [field: SerializeField] 
        public LayerMask InteractableMask { get; private set; }
    }
}