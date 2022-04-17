namespace Cards.Cards.DM06
{
    class LupaPoisonTippedDoll : Creature
    {
        public LupaPoisonTippedDoll() : base("Lupa, Poison-Tipped Doll", 2, 1000, Engine.Race.DeathPuppet, Engine.Civilization.Darkness)
        {
            AddTapAbility(new OneShotEffects.OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(new StaticAbilities.SlayerAbility()));
        }
    }
}
