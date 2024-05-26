using System.Collections.Generic;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    [CreateAssetMenu(fileName = "Stat System", menuName = "PandaEngine/Stat System/Core/Stat System")]
    public class StatSystem : ScriptableObject
    {
        [SerializeField] private List<StatType> statTypes;
        [SerializeField] private List<StatCalculationType> statCalculationTypes;

        public StatType GetStatType(string statId) =>
            statTypes.Find(statType => statType.Id == statId);

        public StatCalculationType GetStatCalculationType(string calculationId) =>
            statCalculationTypes.Find(calculationType => calculationType.Id == calculationId);
    }
}