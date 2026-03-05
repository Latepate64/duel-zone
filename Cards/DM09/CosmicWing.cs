namespace Cards.DM09
{
    sealed class CosmicWing : Spell
    {
        public CosmicWing() : base("Cosmic Wing", 3, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
