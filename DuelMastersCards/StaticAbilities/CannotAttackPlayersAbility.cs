using Cards.CardFilters;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

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
