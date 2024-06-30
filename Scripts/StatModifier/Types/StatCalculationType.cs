using System.Collections.Generic;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    public abstract class StatCalculationType : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private int order;
        [SerializeField] private StatModifierGrouping statModifierGrouping;

        public string Id => id;
        public int Order => order;

        public abstract float ModifyValue(float value, float modifier);
        public abstract string GetValueText(float value);

        public IEnumerable<StatModifier> GetFinalModifiers(IEnumerable<StatModifier> mods) =>
            statModifierGrouping.GetFinalModifiers(mods);
    }
}