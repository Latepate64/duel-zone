using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class StingerWorm : Creature
    {
        public StingerWorm() : base("Stinger Worm", 3, 5000, Common.Subtype.ParasiteWorm, Common.Civilization.Darkness)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new SacrificeEffect()));
        }
    }
}
