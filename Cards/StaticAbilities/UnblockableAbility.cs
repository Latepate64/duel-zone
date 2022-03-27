using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class ThisCreatureCannotBeBlockedAbility : StaticAbility
    {
        public ThisCreatureCannotBeBlockedAbility() : base(new ContinuousEffects.ThisCreatureCannotBeBlockedEffect())
        {
        }
    }

    public class ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerAbility : StaticAbility
    {
        public ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerAbility(int power) : base(new ContinuousEffects.ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(power))
        {
        }
    }
}
