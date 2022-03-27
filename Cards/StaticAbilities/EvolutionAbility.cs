using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class EvolutionAbility : StaticAbility
    {
        public EvolutionAbility(Common.Subtype race) : base(new RaceEvolutionEffect(new Engine.TargetFilter(), race)) { }
    }
}
