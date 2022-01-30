using Cards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace Cards.StaticAbilities
{
    public class AttacksIfAbleAbility : StaticAbility
    {
        public AttacksIfAbleAbility() : base()
        {
            ContinuousEffects.Add(new AttacksIfAbleEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
