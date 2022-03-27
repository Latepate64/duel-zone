using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class RaptorFish : Creature
    {
        public RaptorFish() : base("Raptor Fish", 6, 3000, Subtype.GelFish, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new RaptorFishEffect()));
        }
    }

    class RaptorFishEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = source.GetController(game).Hand.Cards.Count;
            game.Move(ZoneType.Hand, ZoneType.Deck, source.GetController(game).Hand.Cards.ToArray());
            source.GetController(game).ShuffleDeck(game);
            source.GetController(game).DrawCards(amount, game);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new RaptorFishEffect();
        }

        public override string ToString()
        {
            return "Count the cards in your hand, shuffle those cards into your deck, then draw that many cards.";
        }
    }
}
