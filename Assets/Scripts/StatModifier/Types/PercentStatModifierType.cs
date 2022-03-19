using UnityEngine;

[CreateAssetMenu(fileName = "PercentStatModifierType", menuName = "RIG/Base/PercentStatModifierType")]
public class PercentStatModifierType : StatModifierType
{
    public override float ModifyValue(float value, float modifier)
    {
        return value * (1 + modifier);
    }
}