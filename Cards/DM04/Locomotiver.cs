using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM04
{
    class Locomotiver : Engine.Creature
    {
        public Locomotiver() : base("Locomotiver", 4, 1000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
