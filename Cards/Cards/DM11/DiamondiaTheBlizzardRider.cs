﻿using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class DiamondiaTheBlizzardRider : EvolutionCreature
    {
        public DiamondiaTheBlizzardRider() : base("Diamondia, the Blizzard Rider", 3, 5000, Race.SnowFaerie, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new DiamondiaTheBlizzardRiderEffect());
        }
    }

    class DiamondiaTheBlizzardRiderEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand, Controller.Graveyard.Cards.Where(x => x.HasRace(Race.SnowFaerie)).ToArray());
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, Controller.ManaZone.Cards.Where(x => x.HasRace(Race.SnowFaerie)).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new DiamondiaTheBlizzardRiderEffect();
        }

        public override string ToString()
        {
            return "Return all Snow Faeries from your graveyard and your mana zone to your hand.";
        }
    }
}
