using Engine;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class ThisCreatureCannotAttackPlayersAbility : StaticAbility
    {
        public ThisCreatureCannotAttackPlayersAbility(params Condition[] conditions) : base(new ContinuousEffects.ThisCreatureCannotAttackPlayersEffect(conditions))
        {
        }
    }
}
