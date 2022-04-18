using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM08
{
    class Lalicious : Creature
    {
        public Lalicious() : base("Lalicious", 6, 4000, Race.SeaHacker, Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new LaliciousEffect());
        }
    }

    class LaliciousEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            if (source.GetController(game).ChooseToTakeAction(ToString()))
            {
                source.GetController(game).LookAtOpponentsHand(game);
                var cards = source.GetOpponent(game).Deck.GetTopCards(1);
                if (cards.Any())
                {
                    source.GetController(game).Look(source.GetOpponent(game), game, cards.ToArray());
                    source.GetOpponent(game).Unreveal(cards);
                }
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new LaliciousEffect();
        }

        public override string ToString()
        {
            return "You may look at your opponent's hand and at the top card of his deck.";
        }
    }
}
