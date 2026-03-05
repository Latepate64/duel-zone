using ContinuousEffects;

namespace Cards.DM01
{
    sealed class PhantomFish : Creature
    {
        public PhantomFish() : base("Phantom Fish", 3, 4000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
