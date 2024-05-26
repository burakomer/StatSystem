using UnityEngine;

namespace PandaEngine.StatSystem
{
    [CreateAssetMenu(fileName = "FlatStatModifierType", menuName = "RIG/Stats/Types/FlatStatModifierType")]
    public class FlatStatCalculationType : StatCalculationType
    {
        public override float ModifyValue(float value, float modifier)
        {
            return value + modifier;
        }
    }
}