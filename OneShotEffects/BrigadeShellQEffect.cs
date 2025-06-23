using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class BrigadeShellQEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var card = Controller.RevealTopCardOfOwnDeck(game);
        if (card != null && card is ICreature creature)
        {
            if (creature.HasRace(Race.Survivor))
            {
                Controller.PutTopCardOfOwnDeckIntoOwnHand(game, Ability);
            }
            else
            {
                Controller.PutTopCardOfOwnDeckIntoOwnGraveyard(game, Ability);
            }
        }
    }

    public override IOneShotEffect Copy()
    {
        return new BrigadeShellQEffect();
    }

    public override string ToString()
    {
        return "Reveal the top card of your deck. If it's a Survivor, put it into your hand. Otherwise, put it into your graveyard.";
    }
}
