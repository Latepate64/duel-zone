﻿using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM06
{
    class AdomisTheOracle : Creature
    {
        public AdomisTheOracle() : base("Adomis, the Oracle", 3, 2000, Race.LightBringer, Civilization.Light)
        {
            AddTapAbility(new AdomisTheOracleEffect());
        }
    }

    class AdomisTheOracleEffect : CardSelectionEffect
    {
        public AdomisTheOracleEffect() : base(1, 1, true)
        {
        }

        public AdomisTheOracleEffect(AdomisTheOracleEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AdomisTheOracleEffect();
        }

        public override string ToString()
        {
            return "Choose a shield and look at it. Then put it back where it was.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            source.GetController(game).Look(source.GetOpponent(game), game, cards);
            source.GetOpponent(game).Unreveal(cards);
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.Players.SelectMany(x => x.ShieldZone.Cards);
        }
    }
}
