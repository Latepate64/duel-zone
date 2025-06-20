using ContinuousEffects;

namespace Cards.Cards.DM02
{
    class AquaShooter : Engine.Creature
    {
        public AquaShooter() : base("Aqua Shooter", 4, 2000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
