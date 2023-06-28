namespace Engine.ContinuousEffects
{
    public interface ISkipBattleAfterBlockEffect : IContinuousEffect
    {
        bool Applies(ICard attacker, ICard blocker);
    }
}
