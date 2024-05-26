using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    public abstract class StatModifierGrouping : ScriptableObject
    {
        public abstract IEnumerable<StatModifier> GetFinalModifiers(IEnumerable<StatModifier> mods);

        public static IEnumerable<StatModifier> GroupAndOrderModifiers(IEnumerable<StatModifier> mods) =>
            mods.GroupBy(modifier => modifier.CalculationType, modifier => modifier)
                .SelectMany(modiferGrouping => modiferGrouping.Key.GetFinalModifiers(modiferGrouping.ToList()))
                .OrderBy(modifier => modifier.CalculationType.Order);
    }
}