using UnityEngine;

[CreateAssetMenu(fileName = "StatData", menuName = "RIG/StatData")]
public class StatData : ScriptableObject 
{
    public StatType statType;
    public StatModifyType statModifyType;
    public int minValue;
    public int maxValue;
}

public enum StatModifyType 
{
    Flat, Percent
}

public enum StatType 
{
    Vit, Str, Int, Dex, MaxHP, CritChance, CritDamage
}