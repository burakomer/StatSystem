using UnityEngine;

[CreateAssetMenu(fileName = "FullPercentStatModifierType", menuName = "RIG/Stats/Types/FullPercentStatModifierType")]
public class FullPercentStatModifierType : StatModifierType
{
    public override float ModifyValue(float value, float modifier)
    {
        return value * modifier;
    }
}