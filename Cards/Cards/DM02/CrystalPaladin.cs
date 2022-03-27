using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class CrystalPaladin : EvolutionCreature
    {
        public CrystalPaladin() : base("Crystal Paladin", 4, 5000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CrystalPaladinEffect()));
        }
    }

    class CrystalPaladinEffect : OneShotEffects.BounceAreaOfEffect
    {
        public CrystalPaladinEffect() : base(new CardFilters.BattleZoneBlockerCreatureFilter())
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
    }
}
