using Common;

namespace Cards.StaticAbilities
{
    class CrewBreakerAbility : Engine.Abilities.StaticAbility
    {
        public CrewBreakerAbility(Subtype subtype) : base(new ContinuousEffects.CrewBreakerEffect(subtype))
        {
        }
    }
}