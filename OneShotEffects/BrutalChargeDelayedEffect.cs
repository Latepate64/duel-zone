using Interfaces;

namespace OneShotEffects;

public sealed class BrutalChargeDelayedEffect : OneShotEffect
{
    public BrutalChargeDelayedEffect()
    {
    }

    public BrutalChargeDelayedEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        throw new System.NotImplementedException();
        // var shieldsBroken = game.CurrentTurn.GameEvents.OfType<CreatureBreaksShieldsEvent>().Sum(x => x.BreakAmount);
        // var creatures = Controller.ChooseCards(Controller.Deck.Creatures, 0, shieldsBroken, ToString()).ToArray();
        // Controller.ShowCardsToOpponent(game, creatures);
        // game.Move(Ability, ZoneType.Deck, ZoneType.Hand, creatures);
        // Controller.ShuffleOwnDeck(game);
        // Controller.Unreveal(creatures);
    }

    public override IOneShotEffect Copy()
    {
        return new BrutalChargeDelayedEffect(this);
    }

    public override string ToString()
    {
        return "Search your deck. For each of your opponent's shields your creatures broke this turn, you may take a creature from your deck, show it to your opponent, and put it into your hand. Then shuffle your deck.";
    }
}
