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

        public override void Apply(IGame game, IAbility source)
        {
            if (GetController(game).ChooseToTakeAction(ToString()))
            {
                GetController(game).LookAtOpponentsHand(game);
                var cards = GetOpponent(game).Deck.GetTopCards(1);
                if (cards.Any())
                {
                    GetController(game).Look(GetOpponent(game), game, cards.ToArray());
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
