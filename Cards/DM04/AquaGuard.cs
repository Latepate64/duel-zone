using ContinuousEffects;

namespace Cards.DM04
{
    class AquaGuard : Engine.Creature
    {
        public AquaGuard() : base("Aqua Guard", 1, 2000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
