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

        public override void Apply(IGame game)
        {
            var amount = Controller.Hand.Cards.Count;
            game.Move(Ability, ZoneType.Hand, ZoneType.Deck, Controller.Hand.Cards.ToArray());
            Controller.ShuffleOwnDeck(game);
            Controller.DrawCards(amount, game, Ability);
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
