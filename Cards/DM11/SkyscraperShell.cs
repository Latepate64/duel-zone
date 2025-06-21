using TriggeredAbilities;

namespace Cards.DM11
{
    class SkyscraperShell : WaveStrikerCreature
    {
        public SkyscraperShell() : base("Skyscraper Shell", 4, 2000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect()));
        }
    }
}
