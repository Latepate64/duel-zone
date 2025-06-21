namespace Cards.DM09
{
    class CosmicWing : Engine.Spell
    {
        public CosmicWing() : base("Cosmic Wing", 3, Engine.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
