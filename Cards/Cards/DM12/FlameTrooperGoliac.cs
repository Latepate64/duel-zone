using Common;

namespace Cards.Cards.DM12
{
    class FlameTrooperGoliac : WaveStrikerCreature
    {
        public FlameTrooperGoliac() : base("Flame Trooper Goliac", 5, 4000, Engine.Subtype.Armorloid, Civilization.Fire)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(5000)));
        }
    }
}
