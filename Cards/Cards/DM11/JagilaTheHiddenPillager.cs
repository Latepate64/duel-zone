using Common;

namespace Cards.Cards.DM11
{
    class JagilaTheHiddenPillager : WaveStrikerCreature
    {
        public JagilaTheHiddenPillager() : base("Jagila, the Hidden Pillager", 5, 3000, Subtype.PandorasBox, Civilization.Darkness)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.OpponentRandomDiscardEffect(3)));
        }
    }
}
