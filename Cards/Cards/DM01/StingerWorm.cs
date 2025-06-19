using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class StingerWorm : Engine.Creature
    {
        public StingerWorm() : base("Stinger Worm", 3, 5000, Engine.Race.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SacrificeEffect()));
        }
    }
}
