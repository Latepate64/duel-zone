using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class OpponentCannotChooseThisCreatureAbility : StaticAbility
    {
        public OpponentCannotChooseThisCreatureAbility() : base(new ContinuousEffects.OpponentCannotChooseThisCreatureEffect())
        {
        }
    }
}
