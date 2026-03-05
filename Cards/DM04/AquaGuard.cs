using ContinuousEffects;

namespace Cards.DM04
{
    sealed class AquaGuard : Creature
    {
        public AquaGuard() : base("Aqua Guard", 1, 2000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
