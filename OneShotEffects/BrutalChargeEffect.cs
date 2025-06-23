using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class BrutalChargeEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        throw new NotImplementedException();
        // game.AddDelayedTriggeredAbility(new AtTheEndOfTheTurnDelayedTriggeredAbility(Ability, game.CurrentTurn.Id,
        //     new BrutalChargeDelayedEffect()));
    }

    public override IOneShotEffect Copy()
    {
        return new BrutalChargeEffect();
    }

    public override string ToString()
    {
        return "At the end of this turn, search your deck. For each of your opponent's shields your creatures broke this turn, you may take a creature from your deck, show it to your opponent, and put it into your hand. Then shuffle your deck.";
    }
}
