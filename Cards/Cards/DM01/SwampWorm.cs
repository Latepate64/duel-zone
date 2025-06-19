using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class SwampWorm : Creature
    {
        public SwampWorm() : base("Swamp Worm", 7, 2000, Engine.Race.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentSacrificeEffect()));
        }
    }
}
