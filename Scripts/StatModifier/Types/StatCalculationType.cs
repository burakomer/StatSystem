using System.Collections.Generic;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    public abstract class StatCalculationType : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private int order;
        [SerializeField] private string prefix;
        [SerializeField] private StatModifierGrouping statModifierGrouping;

        public string Id => id;
        public int Order => order;
        public string Prefix => prefix;

        public abstract float ModifyValue(float value, float modifier);

        public IEnumerable<StatModifier> GetFinalModifiers(IEnumerable<StatModifier> mods) =>
            statModifierGrouping.GetFinalModifiers(mods);
    }
}