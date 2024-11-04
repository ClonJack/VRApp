using TriInspector;
using UnityEngine;
using UnrealTeam.Common.Additional;
using UnrealTeam.Common.Modules.Configs;
using UnrealTeam.VR.GamePlay.Behaviours;

namespace UnrealTeam.VR.Data.Configs
{   
    [CreateAssetMenu(menuName = "Configs/Player", fileName = nameof(PlayerConfig))]
    public class PlayerConfig : SoSingleConfig
    {
        [field: Title("Reference Behaviour"), SerializeField]
        public AssetComponentReference<PlayerBehaviour> PlayerRef { get; private set; }
    }
}