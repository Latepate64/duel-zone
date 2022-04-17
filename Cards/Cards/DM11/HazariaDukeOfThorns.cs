namespace Cards.Cards.DM11
{
    class HazariaDukeOfThorns : WaveStrikerCreature
    {
        public HazariaDukeOfThorns() : base("Hazaria, Duke of Thorns", 4, 2000, Engine.Race.DarkLord, Engine.Civilization.Darkness)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
