using UnityEngine;

[CreateAssetMenu(fileName = "FlatStatModifierType", menuName = "RIG/Base/FlatStatModifierType")]
public class FlatStatModifierType : StatModifierType
{
    public override float ModifyValue(float value, float modifier)
    {
        return value + modifier;
    }
}