using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class StatModifierGrouping : ScriptableObject
{
    public abstract IEnumerable<StatModifier> GetFinalModifiers(IEnumerable<StatModifier> mods);

    public static IEnumerable<StatModifier> GroupAndOrderModifiers(List<StatModifier> mods) =>
        mods.GroupBy(statMod => statMod.StatModifierType, statMod => statMod)
            .SelectMany(statModsGrouping =>
            {
                var mods = statModsGrouping.ToList();
                return statModsGrouping.Key.GetFinalModifiers(mods);
            })
            .OrderBy(statMod => statMod.StatModifierType.order);
}