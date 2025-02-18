using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace PandaEngine.StatSystem
{
    public delegate void StatModifiersChangedDelegate(IStatModifierSource statModifierSource);

    public interface IStatModifierSource
    {
        public event StatModifiersChangedDelegate OnStatModifiersChanged;
        public Object Source { get; }
        public List<StatModifierData> GetStatModifiersData();
    }
}