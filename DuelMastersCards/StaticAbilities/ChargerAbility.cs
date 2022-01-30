using Cards.CardFilters;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.StaticAbilities
{
    public class ChargerAbility : StaticAbility
    {
        public ChargerAbility()
        {
            ContinuousEffects.Add(new ChargerEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
