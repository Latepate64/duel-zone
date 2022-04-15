using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class MaskedHorrorShadowOfScorn : Creature
    {
        public MaskedHorrorShadowOfScorn() : base("Masked Horror, Shadow of Scorn", 5, 1000, Engine.Subtype.Ghost, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect());
        }
    }
}
