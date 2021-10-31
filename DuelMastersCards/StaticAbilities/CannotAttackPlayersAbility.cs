using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class CannotAttackPlayersAbility : StaticAbility
    {
        public CannotAttackPlayersAbility() : base()
        {
            ContinuousEffects.Add(new CannotAttackPlayersEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
