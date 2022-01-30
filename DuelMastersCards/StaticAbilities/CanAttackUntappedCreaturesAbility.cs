using Cards.CardFilters;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.StaticAbilities
{
    public class CanAttackUntappedCreaturesAbility : StaticAbility
    {
        public CanAttackUntappedCreaturesAbility()
        {
            ContinuousEffects.Add(new CanAttackUntappedCreaturesEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
