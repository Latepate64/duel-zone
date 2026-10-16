using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Destroy all other creatures that have power 6000, then take an extra turn
/// after this one. You lose the game at the end of the extra turn.
/// </summary>
public sealed class BombazarDragonOfDestinyEffect : OneShotEffect
{
    private readonly IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory factory;

    public BombazarDragonOfDestinyEffect(
        IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory factory)
    {
        this.factory = factory;
    }

    public BombazarDragonOfDestinyEffect(
        BombazarDragonOfDestinyEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        game.Destroy(
            Ability,
            [.. game.BattleZone.Creatures.Where(
                p => p != Ability.Source && p.Power == 6000)]);
        // Turn turn = new() { ActivePlayer = Controller, NonActivePlayer = GetOpponent(game) };
        // game.ExtraTurns.Push(turn);
        game.AddDelayedTriggeredAbility(
            factory.Create(
                Ability,
                Guid.NewGuid(),
                new YouLoseTheGameAtTheEndOfTheExtraTurnEffect()));
        throw new NotImplementedException("Extra turn");
    }

    public override IOneShotEffect Copy()
    {
        return new BombazarDragonOfDestinyEffect(this);
    }
}
