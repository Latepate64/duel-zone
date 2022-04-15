namespace Cards.Cards.DM11
{
    class SkyscraperShell : WaveStrikerCreature
    {
        public SkyscraperShell() : base("Skyscraper Shell", 4, 2000, Engine.Subtype.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect()));
        }
    }
}
