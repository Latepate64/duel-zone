using Cards.StaticAbilities;
using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM02
{
    class CrystalPaladin : EvolutionCreature
    {
        public CrystalPaladin() : base("Crystal Paladin", 4, 5000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new CrystalPaladinEffect());
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

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.Creatures.Where(card => card.GetAbilities<BlockerAbility>().Any());
        }
    }
}
