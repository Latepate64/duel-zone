using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class CannotAttackPlayersAbility : StaticAbility
    {
        public CannotAttackPlayersAbility() : base()
        {
            ContinuousEffects.Add(new CannotAttackPlayersEffect());
        }
    }
}
