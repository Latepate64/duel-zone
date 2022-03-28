namespace Cards.StaticAbilities
{
    class ThisCreatureCannotBeAttackedAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCannotBeAttackedAbility() : base(new ContinuousEffects.ThisCreatureCannotBeAttackedEffect())
        {
        }
    }
}