using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    [CreateAssetMenu(fileName = "IndependentStatModifierGrouping", menuName = "RIG/Stats/Grouping/IndependentStatModifierGrouping")]
    public class IndependentStatModifierGrouping : StatModifierGrouping
    {
        public override IEnumerable<StatModifier> GetFinalModifiers(IEnumerable<StatModifier> mods)
            => mods.ToList();
    }
}