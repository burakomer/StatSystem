using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class StatModifierGrouping : ScriptableObject
{
    public abstract IEnumerable<StatModifier> GetFinalModifiers(IEnumerable<StatModifier> mods);

    public static IEnumerable<StatModifier> GroupAndOrderModifiers(IEnumerable<StatModifier> mods) =>
        mods.GroupBy(statMod => statMod.StatModifierType, statMod => statMod)
            .SelectMany(statModsGrouping => statModsGrouping.Key.GetFinalModifiers(statModsGrouping.ToList()))
            .OrderBy(statMod => statMod.StatModifierType.order);
}