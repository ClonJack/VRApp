using _Project.Code.Common.Additional;
using _Project.Code.GamePlay.PlayerController;
using TriInspector;
using UnityEngine;
using UnrealTeam.Common.Configs;

namespace Data.Configs
{   
    [CreateAssetMenu(menuName = "Configs/Player", fileName = nameof(PlayerConfig))]
    public class PlayerConfig : SoSingleConfig
    {
        [Title("Reference Behaviour")]
        [field: SerializeField]
        public AssetComponentReference<PlayerBehaviour> PlayerRef { get; private set; }
    }
}