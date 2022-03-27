using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class ThisCreatureAttacksEachTurnIfAbleAbility : StaticAbility
    {
        public ThisCreatureAttacksEachTurnIfAbleAbility() : base(new ContinuousEffects.ThisCreatureAttacksEachTurnIfAbleEffect())
        {
        }
    }
}
