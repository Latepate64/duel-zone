using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM04
{
    class Locomotiver : Creature
    {
        public Locomotiver() : base("Locomotiver", 4, 1000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
