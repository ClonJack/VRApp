using UnityEngine;

namespace UnrealTeam.Common.Configs
{
    public interface IConfigAccess
    {
        public TConfig GetSingle<TConfig>()
            where TConfig : Object, ISingleConfig;

        public TConfig GetMultiple<TConfig>(string configId)
            where TConfig : Object, IMultipleConfig;

        public TConfig[] GetMultipleAll<TConfig>() 
            where TConfig : Object, IMultipleConfig;
    }
}