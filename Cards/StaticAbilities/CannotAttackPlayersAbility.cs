using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class CannotAttackPlayersAbility : StaticAbility
    {
        public CannotAttackPlayersAbility(params Engine.Condition[] conditions) : base(new CannotAttackPlayersEffect(new Engine.TargetFilter(), conditions))
        {
        }
    }
}
