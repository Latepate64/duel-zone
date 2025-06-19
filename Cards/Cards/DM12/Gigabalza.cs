using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM12
{
    class Gigabalza : Engine.Creature
    {
        public Gigabalza() : base("Gigabalza", 4, 1000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
