using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class SwampWorm : Creature
    {
        public SwampWorm() : base("Swamp Worm", 7, 2000, Common.Subtype.ParasiteWorm, Common.Civilization.Darkness)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OpponentSacrificeEffect()));
        }
    }
}
