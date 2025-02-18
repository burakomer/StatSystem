namespace PandaEngine.StatSystem
{
    public interface IStatModifierTemplate
    {
        string StatId { get; }
        string CalculationId { get; }
        float MinValue { get; }
        float MaxValue { get; }
    }
}