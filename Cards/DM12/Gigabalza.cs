using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12
{
    class Gigabalza : Engine.Creature
    {
        public Gigabalza() : base("Gigabalza", 4, 1000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
