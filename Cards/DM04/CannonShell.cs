using ContinuousEffects;

namespace Cards.DM04
{
    sealed class CannonShell : Engine.Creature
    {
        public CannonShell() : base("Cannon Shell", 4, 1000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureGetsPowerForEachShieldYouHaveEffect(1000));
        }
    }
}
