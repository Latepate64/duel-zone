using Abilities.Triggered;
using OneShotEffects;

namespace Cards.Cards.DM04
{
    class Locomotiver : Engine.Creature
    {
        public Locomotiver() : base("Locomotiver", 4, 1000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
