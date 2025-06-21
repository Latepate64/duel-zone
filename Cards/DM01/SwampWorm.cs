using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    class SwampWorm : Engine.Creature
    {
        public SwampWorm() : base("Swamp Worm", 7, 2000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentSacrificeEffect()));
        }
    }
}
