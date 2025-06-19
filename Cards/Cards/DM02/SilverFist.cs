using Cards.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class SilverFist : Creature
    {
        public SilverFist() : base("Silver Fist", 4, 3000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
