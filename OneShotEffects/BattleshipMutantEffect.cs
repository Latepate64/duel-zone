using TriggeredAbilities;
using Interfaces;
using ContinuousEffects;

namespace OneShotEffects;

public sealed class BattleshipMutantEffect : OneShotEffect
{
    public BattleshipMutantEffect()
    {
    }

    public BattleshipMutantEffect(BattleshipMutantEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new BattleshipMutantContinuousEffect());
        game.AddDelayedTriggeredAbility(new WheneverSomethingHappensThisTurnAbility(
            new BattleshipMutantAbility(game.BattleZone.GetCreatures(Controller.Id, Civilization.Darkness)),
            Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new BattleshipMutantEffect();
    }

    public override string ToString()
    {
        return "Until the end of the turn, each of your darkness creatures in the battle zone gets +4000 power and \"double breaker.\" Whenever any of those creatures battles this turn, destroy it after the battle.";
    }
}
