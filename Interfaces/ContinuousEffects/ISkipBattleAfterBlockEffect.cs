namespace Interfaces.ContinuousEffects
{
    public interface ISkipBattleAfterBlockEffect : IContinuousEffect
    {
        bool Applies(ICreature attacker, ICreature blocker, IGame game);
    }
}
