namespace Cards.Cards.DM09
{
    class CosmicWing : Spell
    {
        public CosmicWing() : base("Cosmic Wing", 3, Common.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
