using System;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace PandaEngine.StatSystem
{
    [Serializable]
    public class StatModifierData : ICloneable
    {
#if ODIN_INSPECTOR
        [ValueDropdown("@OdinUtils.AllStatTypeIdsDropdown")]
#endif
        public string StatId;

#if ODIN_INSPECTOR
        [ValueDropdown("@OdinUtils.AllStatCalculationTypeIdsDropdown")]
#endif
        public string CalculationId;
        public float Value;

        public StatModifierData()
        {
        }

        public StatModifierData(string statId, string calculationId, float value)
        {
            StatId = statId;
            CalculationId = calculationId;
            Value = value;
        }

        public StatModifierData(StatModifierData other) :
            this(other.StatId, other.CalculationId, other.Value)
        {
        }

        public object Clone() => new StatModifierData(this);
    }
}