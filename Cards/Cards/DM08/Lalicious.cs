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
        public LaliciousEffect()
        {
        }

        public LaliciousEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            if (Controller.ChooseToTakeAction(ToString()))
            {
                Controller.LookAtOpponentsHand(game);
                var cards = GetOpponent(game).Deck.GetTopCards(1).ToArray();
                if (cards.Any())
                {
                    Controller.Look(GetOpponent(game), game, cards);
                    GetOpponent(game).Unreveal(cards);
                }
            }
        }

        public override IOneShotEffect Copy()
        {
            return new LaliciousEffect(this);
        }

        public override string ToString()
        {
            return "You may look at your opponent's hand and at the top card of his deck.";
        }
    }
}
