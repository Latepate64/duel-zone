using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class GoldenWingStriker : Creature
    {
        public GoldenWingStriker() : base("Golden Wing Striker", 3, 2000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
