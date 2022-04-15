using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class TimeScout : Creature
    {
        public TimeScout() : base("Time Scout", 2, 1000, Subtype.Merfolk, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TimeScoutEffect());
        }
    }

    class TimeScoutEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = source.GetOpponent(game).Deck.GetTopCards(1);
            if (cards.Any())
            {
                source.GetController(game).Look(source.GetOpponent(game), game, cards.ToArray());
                source.GetOpponent(game).Unreveal(cards);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new TimeScoutEffect();
        }

        public override string ToString()
        {
            return "Look at the top card of your opponent's deck.";
        }
    }
}
