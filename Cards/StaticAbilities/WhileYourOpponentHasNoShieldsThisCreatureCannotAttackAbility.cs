namespace Cards.StaticAbilities
{
    class WhileYourOpponentHasNoShieldsThisCreatureCannotAttackAbility : Engine.Abilities.StaticAbility
    {
        public WhileYourOpponentHasNoShieldsThisCreatureCannotAttackAbility() : base(new ContinuousEffects.WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect())
        {
        }
    }
}