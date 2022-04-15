namespace Cards.Cards.DM06
{
    class LegionnaireLizard : Creature
    {
        public LegionnaireLizard() : base("Legionnaire Lizard", 6, 4000, Engine.Subtype.DuneGecko, Engine.Civilization.Fire)
        {
            AddTapAbility(new OneShotEffects.OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(new StaticAbilities.SpeedAttackerAbility()));
        }
    }
}
