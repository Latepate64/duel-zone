using ContinuousEffects;

namespace Cards.DM02
{
    sealed class AquaShooter : Creature
    {
        public AquaShooter() : base("Aqua Shooter", 4, 2000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
