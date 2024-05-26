using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace PandaEngine.StatSystem
{
    public interface IStatModifierSource
    {
        Object Source { get; }
        List<StatModifierData> GetStatModifiersData();
    }
}