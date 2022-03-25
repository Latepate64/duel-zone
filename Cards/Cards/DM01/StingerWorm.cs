using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class StingerWorm : Creature
    {
        public StingerWorm() : base("Stinger Worm", 3, 5000, Common.Subtype.ParasiteWorm, Common.Civilization.Darkness)
        {
            // When you put this creature into the battle zone, destroy 1 of your creatures.
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new SacrificeEffect()));
        }
    }
}
