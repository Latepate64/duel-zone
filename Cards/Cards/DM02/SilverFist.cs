using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM02
{
    class SilverFist : Engine.Creature
    {
        public SilverFist() : base("Silver Fist", 4, 3000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
