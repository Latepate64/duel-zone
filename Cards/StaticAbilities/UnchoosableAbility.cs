using Cards.CardFilters;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.StaticAbilities
{
    public class UnchoosableAbility : StaticAbility
    {
        public UnchoosableAbility()
        {
            ContinuousEffects.Add(new UnchoosableEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
