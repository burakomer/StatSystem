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
        [SerializeField] private string statId;
        [SerializeField] private string calculationId;
        [SerializeField] private float minValue;
        [SerializeField] private float maxValue;

        public string StatId => statId;
        public string CalculationId => calculationId;
        public float MinValue => minValue;
        public float MaxValue => maxValue;
    }
}