using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class BarkwhipTheSmasher : EvolutionCreature
    {
        public BarkwhipTheSmasher() : base("Barkwhip, the Smasher", 2, 5000, Subtype.BeastFolk, Civilization.Nature)
        {
            AddAbilities(new StaticAbility(new Engine.ContinuousEffects.PowerModifyingEffect(2000, new CardFilters.OwnersBattleZoneCreatureExceptFilter(Subtype.BeastFolk), new Engine.Durations.Indefinite(), new Conditions.TappedCondition(new Engine.TargetFilter()))));
        }
    }
}
