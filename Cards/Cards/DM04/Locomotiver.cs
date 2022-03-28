using Cards.OneShotEffects;

namespace Cards.Cards.DM04
{
    class Locomotiver : Creature
    {
        public Locomotiver() : base("Locomotiver", 4, 1000, Common.Subtype.Hedrian, Common.Civilization.Darkness)
        {
            ShieldTrigger = true;
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect());
        }
    }
}
