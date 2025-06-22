using TriggeredAbilities;

namespace Cards.DM12
{
    sealed class SteamrollerMutant : WaveStrikerCreature
    {
        public SteamrollerMutant() : base("Steamroller Mutant", 4, 3000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyAllCreaturesEffect()));
        }
    }
}
