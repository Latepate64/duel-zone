using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class EvolutionAbility : StaticAbility
    {
        public EvolutionAbility(Common.Subtype race) : base(new Engine.ContinuousEffects.RaceEvolutionEffect(new Engine.TargetFilter(), race)) { } // TODO: Implement effect.
    }
}
