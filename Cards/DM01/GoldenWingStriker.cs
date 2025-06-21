using ContinuousEffects;

namespace Cards.DM01
{
    class GoldenWingStriker : Engine.Creature
    {
        public GoldenWingStriker() : base("Golden Wing Striker", 3, 2000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
