using TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM02
{
    class CrystalPaladin : EvolutionCreature
    {
        public CrystalPaladin() : base("Crystal Paladin", 4, 5000, Race.LiquidPeople, Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CrystalPaladinEffect()));
        }
    }

    class CrystalPaladinEffect : OneShotEffects.BounceAreaOfEffect
    {
        public CrystalPaladinEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CrystalPaladinEffect();
        }

        public override string ToString()
        {
            return "Return all creatures in the battle zone that have \"blocker\" to their owners' hands.";
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.CreaturesThatHaveBlocker;
        }
    }
}
