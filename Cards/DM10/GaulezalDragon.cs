using ContinuousEffects;

namespace Cards.DM10
{
    class GaulezalDragon : Engine.Creature
    {
        public GaulezalDragon() : base("Gaulezal Dragon", 9, 11000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
