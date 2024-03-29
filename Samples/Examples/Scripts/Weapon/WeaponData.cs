using System.Collections.Generic;
using UnityEngine;

namespace PandaEngine.StatSystem.Examples
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "RIG/Item/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        [Header("Settings")]
        public string itemName;
        public int statCount;

        [Header("Damage")]
        public StatModifierTemplateStruct baseDamage;

        [Space]
        public List<StatModifierTemplateScriptableDelegate> possibleStatModifiers;
    }
}