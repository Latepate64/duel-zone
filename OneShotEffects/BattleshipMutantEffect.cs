using TriggeredAbilities;
using Interfaces;
using ContinuousEffects.AbilityAddingPowerModifying;

namespace OneShotEffects;

/// <summary>
/// Until the end of the turn, each of your creatures in the battle zone gets +x
/// power and "double breaker." Whenever any of those creatures battles this
/// turn, destroy it after the battle.
/// </summary>
public sealed class BattleshipMutantEffect : OneShotEffect
{
    private readonly int power;
    private readonly ICardFilter filter;

    public BattleshipMutantEffect(int power, ICardFilter filter)
    {
        this.power = power;
        this.filter = filter;
    }

    public BattleshipMutantEffect(BattleshipMutantEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability, new BattleshipMutantContinuousEffect(power, filter));
        game.AddDelayedTriggeredAbility(
            new WheneverSomethingHappensThisTurnAbility(
            new BattleshipMutantAbility(
                game.BattleZone.GetCreaturesControllerByPlayer(
                    Applier, filter)),
            Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new BattleshipMutantEffect(this);
    }
}
