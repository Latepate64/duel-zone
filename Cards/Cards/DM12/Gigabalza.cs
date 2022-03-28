using Cards.OneShotEffects;

namespace Cards.Cards.DM12
{
    class Gigabalza : Creature
    {
        public Gigabalza() : base("Gigabalza", 4, 1000, Common.Subtype.Chimera, Common.Civilization.Darkness)
        {
            ShieldTrigger = true;
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect());
        }
    }
}
