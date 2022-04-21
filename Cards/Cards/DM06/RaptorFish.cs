﻿using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class RaptorFish : Creature
    {
        public RaptorFish() : base("Raptor Fish", 6, 3000, Race.GelFish, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new RaptorFishEffect());
        }
    }

    class RaptorFishEffect : OneShotEffect
    {
        public RaptorFishEffect()
        {
        }

        public RaptorFishEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game, IAbility source)
        {
            var amount = GetController(game).Hand.Cards.Count;
            game.Move(source, ZoneType.Hand, ZoneType.Deck, GetController(game).Hand.Cards.ToArray());
            GetController(game).ShuffleDeck(game);
            GetController(game).DrawCards(amount, game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new RaptorFishEffect(this);
        }

        public override string ToString()
        {
            return "Count the cards in your hand, shuffle those cards into your deck, then draw that many cards.";
        }
    }
}
