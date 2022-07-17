using UnityEngine;

[CreateAssetMenu(fileName = "PercentStatModifierType", menuName = "RIG/Stats/Types/PercentStatModifierType")]
public class PercentStatModifierType : StatModifierType
{
    public override float ModifyValue(float value, float modifier)
    {
        return value * (1 + modifier);
    }
}