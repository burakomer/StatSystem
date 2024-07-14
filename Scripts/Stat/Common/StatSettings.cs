using System;

namespace PandaEngine.StatSystem
{
    [Serializable]
    public struct StatSettings : IStatSettings
    {
        public StatType statType;
        public float initialBaseValue;

        public StatType StatType => statType;
        public float InitialBaseValue => initialBaseValue;

        public StatSettings(StatType statType, float initialBaseValue)
        {
            this.statType = statType;
            this.initialBaseValue = initialBaseValue;
        }
    }
}