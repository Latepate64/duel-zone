using TriggeredAbilities;

namespace Cards.DM11
{
    sealed class HazariaDukeOfThorns : WaveStrikerCreature
    {
        public HazariaDukeOfThorns() : base("Hazaria, Duke of Thorns", 4, 2000, Interfaces.Race.DarkLord, Interfaces.Civilization.Darkness)
        {
            AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
