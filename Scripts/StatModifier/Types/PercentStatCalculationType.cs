using UnityEngine;

namespace PandaEngine.StatSystem
{
    [CreateAssetMenu(fileName = "PercentStatModifierType", menuName = "RIG/Stats/Types/PercentStatModifierType")]
    public class PercentStatCalculationType : StatCalculationType
    {
        public override float ModifyValue(float value, float modifier)
        {
            return value * (1 + modifier);
        }

        public override string GetValueText(float value)
        {
            return $"+{value * 100:F1}%";
        }
    }
}