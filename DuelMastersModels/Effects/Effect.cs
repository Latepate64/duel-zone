namespace DuelMastersModels.Effects
{
    /// <summary>
    /// 609.1. An effect is something that happens in the game as a result of a spell or ability. When a spell, activated ability, or triggered ability resolves, it may create one or more one-shot or continuous effects. Static abilities may create one or more continuous effects. Text itself is never an effect.
    /// </summary>
    public abstract class Effect
    {
        protected Effect() { }
    }
}
