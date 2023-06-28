using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class TimeScout : Creature
    {
        public TimeScout() : base("Time Scout", 2, 1000, Race.Merfolk, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TimeScoutEffect());
        }
    }

    class TimeScoutEffect : OneShotEffect
    {
        public override void Apply()
        {
            var cards = Applier.Opponent.Deck.GetTopCards(1).ToArray();
            if (cards.Any())
            {
                Applier.Look(Applier.Opponent, cards);
                Applier.Opponent.Unreveal(cards);
            }
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
