namespace Cards.Cards.DM09
{
    class CosmicWing : Spell
    {
        public CosmicWing() : base("Cosmic Wing", 3, Engine.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
