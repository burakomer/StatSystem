using System.Collections.Generic;

public interface IStatUser
{
    void ApplyStatModifier(StatModifier statModifier);
    void ApplyStatModifiers(List<StatModifier> statModifiers);
    void RemoveAllModifiersFromSource(IStatModifierSource statModifierSource);
}