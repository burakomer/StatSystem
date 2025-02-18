using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    [CreateAssetMenu(fileName = "MultiplicativeStatModifierGrouping", menuName = "RIG/Stats/Grouping/MultiplicativeStatModifierGrouping")]
    public class MultiplicativeStatModifierGrouping : StatModifierGrouping
    {
        public override IEnumerable<StatModifier> GetFinalModifiers(IEnumerable<StatModifier> mods)
            => new[]
            {
                mods.Aggregate((prev, curr) =>
                {
                    curr.Value *= prev.Value;
                    return curr;
                })
            };
    }
}