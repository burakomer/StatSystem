namespace PandaEngine.StatSystem
{
    public interface IStatSettings
    {
        public StatType StatType { get; }
        public float InitialBaseValue { get; }
    }
}