using UnityEngine;

namespace PandaEngine.StatSystem
{
    [CreateAssetMenu(fileName = "FullPercentStatModifierType", menuName = "RIG/Stats/Types/FullPercentStatModifierType")]
    public class FullPercentStatCalculationType : StatCalculationType
    {
        public override float ModifyValue(float value, float modifier)
        {
            return value * modifier;
        }

        public override string GetValueText(float value)
        {
            return $"x{value * 100:F1}%";
        }
    }
}