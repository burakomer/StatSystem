using System;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    /// <summary>
    /// Used for serialization inside likely another asset. To avoid having multiple assets just for one asset.
    /// </summary>
    [Serializable]
    public struct StatModifierTemplateStruct : IStatModifierTemplate
    {
        [SerializeField] private StatType statType;
        [SerializeField] private StatModifierType statModifierType;
        [SerializeField] private float minValue;
        [SerializeField] private float maxValue;

        public StatType StatType => statType;
        public StatModifierType StatModifierType => statModifierType;
        public float MinValue => minValue;
        public float MaxValue => maxValue;
    }
}