using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AdditiveStatModifierGrouping", menuName = "RIG/Stats/Grouping/AdditiveStatModifierGrouping")]
public class AdditiveStatModifierGrouping : StatModifierGrouping
{
    public override IEnumerable<StatModifier> GetFinalModifiers(IEnumerable<StatModifier> mods)
        => new[]
        {
            mods.Aggregate((prev, curr) =>
            {
                curr.Value += prev.Value;
                return curr;
            })
        };
}