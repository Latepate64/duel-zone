using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class StingerWorm : Creature
    {
        public StingerWorm() : base("Stinger Worm", 3, 5000, Engine.Subtype.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new SacrificeEffect());
        }
    }
}
