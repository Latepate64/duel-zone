using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class BarkwhipTheSmasher : EvolutionCreature
    {
        public BarkwhipTheSmasher() : base("Barkwhip, the Smasher", 2, 5000, Subtype.BeastFolk, Civilization.Nature)
        {
            AddStaticAbilities(new BarkwhipTheSmasherEffect());
        }
    }

    class BarkwhipTheSmasherEffect : PowerModifyingEffect
    {
        public BarkwhipTheSmasherEffect() : base(2000, new CardFilters.OwnersBattleZoneSubtypeCreatureExceptFilter(Subtype.BeastFolk), new Durations.Indefinite(), new Conditions.TappedCondition(new Engine.TargetFilter()))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new BarkwhipTheSmasherEffect();
        }

        public override string ToString()
        {
            return "While this creature is tapped, each of your other Beast Folk in the battle zone gets +2000 power.";
        }
    }
}
