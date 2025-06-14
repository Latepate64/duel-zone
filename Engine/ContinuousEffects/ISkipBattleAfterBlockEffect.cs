namespace Engine.ContinuousEffects
{
    public interface ISkipBattleAfterBlockEffect : IContinuousEffect
    {
        bool Applies(Card attacker, Card blocker, IGame game);
    }
}
