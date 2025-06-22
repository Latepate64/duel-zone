using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    sealed class StingerWorm : Engine.Creature
    {
        public StingerWorm() : base("Stinger Worm", 3, 5000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SacrificeEffect()));
        }
    }
}
