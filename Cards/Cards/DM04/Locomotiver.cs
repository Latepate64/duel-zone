using Cards.OneShotEffects;

namespace Cards.Cards.DM04
{
    class Locomotiver : Creature
    {
        public Locomotiver() : base("Locomotiver", 4, 1000, Engine.Subtype.Hedrian, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect());
        }
    }
}
