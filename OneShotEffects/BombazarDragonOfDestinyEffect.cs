using Interfaces;

namespace OneShotEffects;

public sealed class BombazarDragonOfDestinyEffect : OneShotEffect
{
    public BombazarDragonOfDestinyEffect()
    {
    }

    public BombazarDragonOfDestinyEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        throw new System.NotImplementedException();
        // game.Destroy(Ability, [.. game.BattleZone.Creatures.Where(p => p != Ability.Source && p.Power.Value == 6000)]);
        // Turn turn = new() { ActivePlayer = Controller, NonActivePlayer = GetOpponent(game) };
        // game.ExtraTurns.Push(turn);
        // game.AddDelayedTriggeredAbility(new AtTheEndOfTheTurnDelayedTriggeredAbility(
        //     Ability, turn.Id, new YouLoseTheGameAtTheEndOfTheExtraTurnEffect()));
    }

    public override IOneShotEffect Copy()
    {
        return new BombazarDragonOfDestinyEffect(this);
    }

    public override string ToString()
    {
        return "Destroy all other creatures that have power 6000, then take an extra turn after this one. You lose the game at the end of the extra turn.";
    }
}
