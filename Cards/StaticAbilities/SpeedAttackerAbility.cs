using Cards.CardFilters;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.StaticAbilities
{
    public class SpeedAttackerAbility : StaticAbility
    {
        public SpeedAttackerAbility() : base()
        {
            ContinuousEffects.Add(new SpeedAttackerEffect(new TargetFilter(), new Indefinite()));
        }
    }
}

