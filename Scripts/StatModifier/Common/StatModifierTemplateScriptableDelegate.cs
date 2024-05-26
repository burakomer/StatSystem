using UnityEngine;

namespace PandaEngine.StatSystem
{
    /// <summary>
    /// Used for generic purposes.
    /// </summary>
    [CreateAssetMenu(fileName = "StatModifierTemplate", menuName = "RIG/Stats/Common/StatModifierTemplate")]
    public class StatModifierTemplateScriptableDelegate : ScriptableObject, IStatModifierTemplate
    {
        [SerializeField] private StatModifierTemplateStruct template;

        public string StatId => template.StatId;
        public string CalculationId => template.CalculationId;
        public float MinValue => template.MinValue;
        public float MaxValue => template.MaxValue;
    }
}