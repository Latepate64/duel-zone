﻿using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM02
{
    class LarbaGeerTheImmaculate : EvolutionCreature
    {
        public LarbaGeerTheImmaculate() : base("Larba Geer, the Immaculate", 3, 5000, Race.Guardian, Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new LarbaGeerTheImmaculateEffect());
        }
    }

    class LarbaGeerTheImmaculateEffect : OneShotEffects.TapAreaOfEffect
    {
        public LarbaGeerTheImmaculateEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new LarbaGeerTheImmaculateEffect();
        }

        public override string ToString()
        {
            return "Tap all your opponent's creatures in the battle zone that have \"blocker.\"";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(game.GetOpponent(Ability.Controller.Id)).Where(x => x.GetAbilities<BlockerAbility>().Any());
        }
    }
}
