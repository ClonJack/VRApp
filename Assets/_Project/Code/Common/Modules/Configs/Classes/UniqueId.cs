using System;
using UnityEngine;

namespace UnrealTeam.Common.Configs
{
    [Serializable]
    public class UniqueId
    {
        [field: SerializeField] public string Value { get; set; }
    }
}