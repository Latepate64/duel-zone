namespace Cards.StaticAbilities
{
    class ThisCreatureGetsPowerAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureGetsPowerAbility(int power) : base(new Engine.ContinuousEffects.PowerModifyingEffect(power))
        {
        }
    }
}
