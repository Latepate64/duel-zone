using Cards.CardFilters;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.StaticAbilities
{
    public class CannotAttackCreaturesAbility : StaticAbility
    {
        public CannotAttackCreaturesAbility() : base()
        {
            ContinuousEffects.Add(new CannotAttackCreaturesEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
