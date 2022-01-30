using Cards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace Cards.StaticAbilities
{
    public class CannotAttackPlayersAbility : StaticAbility
    {
        public CannotAttackPlayersAbility() : base()
        {
            ContinuousEffects.Add(new CannotAttackPlayersEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
