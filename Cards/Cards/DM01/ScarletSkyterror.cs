﻿using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM01
{
    class ScarletSkyterror : Creature
    {
        public ScarletSkyterror() : base("Scarlet Skyterror", 8, 3000, Race.ArmoredWyvern, Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new ScarletSkyterrorEffect());
        }
    }

    class ScarletSkyterrorEffect : DestroyAreaOfEffect
    {
        public ScarletSkyterrorEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ScarletSkyterrorEffect();
        }

        public override string ToString()
        {
            return "Destroy all creatures that have \"blocker.\"";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.Creatures.Where(x => x.GetAbilities<BlockerAbility>().Any());
        }
    }
}
