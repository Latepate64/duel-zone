using Common;

namespace Cards.Cards.DM11
{
    class HazariaDukeOfThorns : WaveStrikerCreature
    {
        public HazariaDukeOfThorns() : base("Hazaria, Duke of Thorns", 4, 2000, Engine.Subtype.DarkLord, Civilization.Darkness)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
