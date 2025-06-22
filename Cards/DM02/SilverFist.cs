using ContinuousEffects;

namespace Cards.DM02
{
    sealed class SilverFist : Engine.Creature
    {
        public SilverFist() : base("Silver Fist", 4, 3000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
