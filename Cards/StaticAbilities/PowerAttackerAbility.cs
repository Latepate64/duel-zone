using Cards.CardFilters;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.StaticAbilities
{
    public class PowerAttackerAbility : StaticAbility
    {
        public PowerAttackerAbility(int power)
        {
            ContinuousEffects.Add(new PowerAttackerEffect(new TargetFilter(), new Indefinite(), power));
        }
    }
}
