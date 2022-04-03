﻿using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class RainbowGate : Spell
    {
        public RainbowGate() : base("Rainbow Gate", 2, Civilization.Nature)
        {
            AddSpellAbilities(new RainbowGateEffect());
        }
    }

    class RainbowGateEffect : OneShotEffects.SearchEffect
    {
        public RainbowGateEffect() : base(new RainbowGateFilter(), true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new RainbowGateEffect();
        }

        public override string ToString()
        {
            return "Search your deck. You may take a multi-colored creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }

    class RainbowGateFilter : CardFilters.OwnersDeckCreatureFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.IsMultiColored;
        }

        public override CardFilter Copy()
        {
            return new RainbowGateFilter();
        }
    }
}