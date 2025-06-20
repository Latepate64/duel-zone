using Abilities.Triggered;
using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class SwampWorm : Engine.Creature
    {
        public SwampWorm() : base("Swamp Worm", 7, 2000, Engine.Race.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentSacrificeEffect()));
        }
    }
}
