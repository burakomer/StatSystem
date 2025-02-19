using System;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    [Serializable]
    public class StatValueReference
    {
        public enum StatReferenceType
        {
            LocalStat,
            StatsController,
        }

        [SerializeField] private StatReferenceType statReferenceType;
        [SerializeField] private Stat localStat;
        [SerializeField] private StatsController statsController;
        [SerializeField] private StatType statType;

        public float Value
        {
            get
            {
                switch (statReferenceType)
                {
                    case StatReferenceType.StatsController:
                        return statsController.GetStat(statType).Value;
                    case StatReferenceType.LocalStat:
                    default:
                        return localStat.Value;
                }
            }
        }

        public event Action<StatValueChangeArgs> OnValueUpdated
        {
            add
            {
                switch (statReferenceType)
                {
                    case StatReferenceType.StatsController:
                        statsController.GetStat(statType).OnValueUpdated += value;
                        break;
                    case StatReferenceType.LocalStat:
                    default:
                        localStat.OnValueUpdated += value;
                        break;
                }
            }
            remove
            {
                switch (statReferenceType)
                {
                    case StatReferenceType.StatsController:
                        statsController.GetStat(statType).OnValueUpdated -= value;
                        break;
                    case StatReferenceType.LocalStat:
                    default:
                        localStat.OnValueUpdated -= value;
                        break;
                }
            }
        }

        public StatValueReference(float value)
        {
            statReferenceType = StatReferenceType.LocalStat;
            localStat = new Stat(null, value);
            statsController = null;
            statType = null;
        }

        public StatValueReference(Stat stat)
        {
            statReferenceType = StatReferenceType.LocalStat;
            localStat = stat;
            statsController = null;
            statType = null;
        }

        public StatValueReference(StatsController controller, StatType type)
        {
            statReferenceType = StatReferenceType.StatsController;
            localStat = null;
            statsController = controller;
            statType = type;
        }
    }
}