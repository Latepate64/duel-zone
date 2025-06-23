using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    sealed class SwampWorm : Creature
    {
        public SwampWorm() : base("Swamp Worm", 7, 2000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentSacrificeEffect()));
        }
    }
}
