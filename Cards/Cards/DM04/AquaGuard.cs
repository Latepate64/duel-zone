using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class AquaGuard : Engine.Creature
    {
        public AquaGuard() : base("Aqua Guard", 1, 2000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
