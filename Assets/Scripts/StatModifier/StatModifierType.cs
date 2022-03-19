using UnityEngine;

public abstract class StatModifierType : ScriptableObject 
{
    public int order;
    public string prefix;

    public abstract float ModifyValue(float value, float modifier);
}