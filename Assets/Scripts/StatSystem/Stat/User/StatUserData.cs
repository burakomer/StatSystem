using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "StatUserData", menuName = "RIG/Stats/User/StatUserData")]
public class StatUserData : ScriptableObject
{
    [SerializeField] private List<StatType> statTypes;

    public Dictionary<StatType, Stat> CreateStatDictionaryFromTypes() => 
        statTypes
            .Select(type => new Stat(type))
            .ToDictionary(stat => stat.StatType, stat => stat);
}