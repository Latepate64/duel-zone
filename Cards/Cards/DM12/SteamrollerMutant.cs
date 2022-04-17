namespace Cards.Cards.DM12
{
    class SteamrollerMutant : WaveStrikerCreature
    {
        public SteamrollerMutant() : base("Steamroller Mutant", 4, 3000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyAllCreaturesEffect()));
        }
    }
}
