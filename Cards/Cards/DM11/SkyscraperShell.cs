using TriggeredAbilities;

namespace Cards.Cards.DM11
{
    class SkyscraperShell : WaveStrikerCreature
    {
        public SkyscraperShell() : base("Skyscraper Shell", 4, 2000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect()));
        }
    }
}
