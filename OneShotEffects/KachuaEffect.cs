using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class KachuaEffect : OneShotEffect
{
    public KachuaEffect()
    {
    }

    public KachuaEffect(KachuaEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var cards = Controller.Deck.Creatures.Where(x => x.IsDragon);
        var dragon = Controller.ChooseCardOptionally(cards, ToString()) as ICreature;
        if (dragon != null)
        {
            game.Move(Ability, ZoneType.Deck, ZoneType.Hand, dragon);
        }
        Controller.ShuffleOwnDeck(game);
        if (dragon != null)
        {
            game.AddContinuousEffects(Ability, new KachuaContinuousEffect(dragon));
            throw new NotImplementedException();
            // game.AddDelayedTriggeredAbility(new KachuaDelayedTriggeredAbility(Ability, dragon, game.CurrentTurn.Id));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new KachuaEffect(this);
    }

    public override string ToString()
    {
        return "Search your deck. You may take a creature that has Dragon in its race from your deck and put it into the battle zone. Then shuffle your deck. That creature has \"speed attacker.\" At the end of the turn, destroy it.";
    }
}
