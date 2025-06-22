using ContinuousEffects;

namespace Cards.DM01
{
    sealed class GoldenWingStriker : Engine.Creature
    {
        public GoldenWingStriker() : base("Golden Wing Striker", 3, 2000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
