using System;
using Sirenix.OdinInspector;

[Serializable]
public struct StatValueReference
{
    public enum StatReferenceType
    {
        Primitive,
        StatController
    }
    
    public StatReferenceType statReferenceType;
    
    [ShowIf(nameof(statReferenceType), StatReferenceType.Primitive)] [LabelText("Value")]
    public float primitiveValue;
    
    [ShowIf(nameof(statReferenceType), StatReferenceType.StatController)] [LabelText("Value")]
    public StatController statController;
    
    public float Value
    {
        get
        {
            switch (statReferenceType)
            {
                case StatReferenceType.StatController:
                    return statController.Stat.Value;
                case StatReferenceType.Primitive:
                default:
                    return primitiveValue;
                    
            }
        }
    }
}