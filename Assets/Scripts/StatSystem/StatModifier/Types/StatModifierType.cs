using System.Collections.Generic;
using UnityEngine;

public abstract class StatModifierType : ScriptableObject
{
    public int order;
    public string prefix;
    public StatModifierGrouping statModifierGrouping;

    public abstract float ModifyValue(float value, float modifier);

    public IEnumerable<StatModifier> GetFinalModifiers(IEnumerable<StatModifier> mods) => 
        statModifierGrouping.GetFinalModifiers(mods);
}