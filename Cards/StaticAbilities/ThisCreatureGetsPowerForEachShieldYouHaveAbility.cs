using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class ThisCreatureGetsPowerForEachShieldYouHaveAbility : StaticAbility
    {
        public ThisCreatureGetsPowerForEachShieldYouHaveAbility(int power) : base(new ContinuousEffects.ThisCreatureGetsPowerForEachShieldYouHaveEffect(power))
        {
        }
    }
}
