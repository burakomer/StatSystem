using System;

namespace PandaEngine.StatSystem
{
    [Serializable]
    public class StatModifierData : ICloneable
    {
        public string StatId;
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