using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirenix.OdinInspector;
using UnityEngine;

public class StatControllersGroup : MonoBehaviour, IStatUser
{
    [Header("References")]
    [SerializeField] private List<StatController> statControllers;
    
    [Header("Debug")]
    [SerializeField] private bool showDebugInfo;
    
    private Dictionary<StatType, StatController> statsByType;

    private void Awake()
    {
        statsByType = statControllers.ToDictionary(statController => statController.Stat.StatType, statController => statController);
    }

    public void ApplyStatModifier(StatModifier statModifier)
    {
        if (!statsByType.TryGetValue(statModifier.StatType, out var stat))
            return;
        stat.ApplyStatModifier(statModifier);
    }

    public void ApplyStatModifiers(List<StatModifier> statModifiers)
    {
        foreach (var statModifier in statModifiers)
            ApplyStatModifier(statModifier);
    }

    public void RemoveAllModifiersFromSource(IStatModifierSource statModifierSource)
    {
        foreach (var stat in statsByType.Values)
            stat.RemoveAllModifiersFromSource(statModifierSource);
    }

    private void OnGUI()
    {
        if (!showDebugInfo)
            return;
        
        var sb = new StringBuilder();

        foreach (var statController in statsByType.Values)
        {
            var stat = statController.Stat;
            sb.AppendLine($"<b>{stat.StatType.displayName}:</b> {stat.Value} {(stat.BaseValue)}");

            foreach (var statMod in stat.StatModifiers)
                sb.Append($" {statMod.ValueDescription}");
        }

        var style = new GUIStyle
        {
            fontSize = 24
        };

        GUI.Label(new Rect(0, 0, 2000, 500), sb.ToString(), style);
    }

    [Button]
    private void GetStatControllersInChildren()
    {
        statControllers = GetComponentsInChildren<StatController>().ToList();
    }
}