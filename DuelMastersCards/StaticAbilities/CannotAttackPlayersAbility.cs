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

        public CannotAttackPlayersAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new CannotAttackPlayersAbility(this);
        }
    }
}
