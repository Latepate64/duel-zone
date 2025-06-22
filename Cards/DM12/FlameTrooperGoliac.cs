using TriggeredAbilities;

namespace Cards.DM12
{
    sealed class FlameTrooperGoliac : WaveStrikerCreature
    {
        public FlameTrooperGoliac() : base("Flame Trooper Goliac", 5, 4000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(5000)));
        }
    }
}
