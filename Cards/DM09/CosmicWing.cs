namespace Cards.DM09
{
    class CosmicWing : Engine.Spell
    {
        public CosmicWing() : base("Cosmic Wing", 3, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
